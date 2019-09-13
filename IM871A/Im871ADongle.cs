// <copyright file="Im871ADongle.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading.Tasks;
using IM871A.DependencyInjection;
using IM871A.Messaging;
using IM871A.Utilities.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace IM871A
{
    /// <summary>
    /// Represents a physical iMST iM871A Dongle.
    /// </summary>
    public class Im871ADongle
    {
        private const byte StartOfFrame = 0xA5;

        private readonly ILogger<Im871ADongle> _logger;
        private readonly SerialPort _serialConnection;

        private Func<HciMessage, Task> _onData;

        /// <summary>
        /// Initializes a new instance of the <see cref="Im871ADongle"/> class.
        /// </summary>
        /// <param name="options">the options.</param>
        /// <param name="loggerFactory">a logger factory.</param>
        public Im871ADongle(IOptions<ConfigurationOptions> options, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Im871ADongle>();

            ConfigurationOptions opts = options.Value;

            _serialConnection = new SerialPort(
                portName: opts.PortName,
                baudRate: opts.BaudRate,
                parity: Parity.None,
                dataBits: 8,
                stopBits: StopBits.One);

            _serialConnection.DataReceived += OnSerialDataAvailable;
            _logger.LogDebug("Opening serial connection...");
            _serialConnection.Open();
        }

        /// <summary>
        /// Set the action to be triggered, when new data is available.
        /// </summary>
        /// <param name="onData">the action to be triggered.</param>
        public void SetReceiver(Func<HciMessage, Task> onData)
        {
            _onData = onData ?? throw new ArgumentNullException(nameof(onData));
        }

        /// <summary>
        /// Transmits the passed <paramref name="message"/> to the physical dongle.
        /// </summary>
        /// <param name="message">the message to be sent.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task TransmitMessage(HciMessage message)
        {
            if (!(message is ITransmittable))
            {
                throw new ArgumentException($"{message} not marked as {nameof(ITransmittable)}");
            }

            return TransmitMessageInternalAsync(message);
        }

        private async Task TransmitMessageInternalAsync(HciMessage message)
        {
            // TODO: give CRC16? Already have the calculations available through stuff made for the Iu880B.
            byte controlField = 0b0000_0000;
            var endpointId = (byte)message.EndpointIdentifier;

            var combinedControlFieldAndEndPointId = BitwiseExtensions.ConcatBytes(controlField, endpointId);

            var bytes = new List<byte>() { StartOfFrame, combinedControlFieldAndEndPointId, message.MessageIdentifier };

            IList<byte> payload = message.Payload;

            if (payload.Count > 0)
            {
                var length = checked((byte)payload.Count);
                bytes.Add(length);
                bytes.AddRange(payload);
            }

            await _serialConnection.BaseStream.WriteAsync(bytes.ToArray(), 0, bytes.Count);
        }

        private void OnSerialDataAvailable(object sender, SerialDataReceivedEventArgs e)
        {
            MarshalData().Wait();
        }

        private async Task MarshalData()
        {
            Stream stream = _serialConnection.BaseStream;

            var buffer = new byte[512];
            var readBytesCount = await stream.ReadAsync(buffer, 0, 3);

            if (readBytesCount > 0)
            {
                var controlField = (byte)buffer[0].HighNibble();
                var endpointId = (byte)buffer[0].LowNibble();

                var messageId = buffer[1];
                var lengthField = buffer[2];
                var payload = new byte[2];

                if (lengthField > 0)
                {
                    var readLength = lengthField;
                    var timestampPresent = controlField.GetBit(2);
                    var rssiPresent = controlField.GetBit(3);
                    var crcPresent = controlField.GetBit(4);
                    if (timestampPresent)
                    {
                        readLength += 4; // 32bit
                    }

                    if (rssiPresent)
                    {
                        readLength += 1; // 8bit
                    }

                    if (crcPresent)
                    {
                        readLength += 2; // 16bit
                    }

                    await stream.ReadAsync(buffer, 0, readLength);

                    // TODO: Handle optional fields
                    payload = new byte[lengthField + 2];
                    Buffer.BlockCopy(buffer, 3, payload, 2, lengthField);
                }

                payload[0] = endpointId;
                payload[1] = messageId;

                await _onData((HciMessage)ReceivableMessageFactory.Create(payload));
            }
        }
    }
}