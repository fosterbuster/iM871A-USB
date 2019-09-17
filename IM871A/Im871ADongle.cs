// <copyright file="IM871ADongle.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Threading.Tasks;
using FosterBuster.Extensions;
using FosterBuster.IM871A.DependencyInjection;
using FosterBuster.IM871A.Messaging;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FosterBuster.IM871A
{
    /// <summary>
    /// Represents a physical iMST iM871A Dongle.
    /// </summary>
    public class IM871ADongle
    {
        private const byte StartOfFrame = 0xA5;

        private readonly ILogger<IM871ADongle> _logger;
        private readonly SerialPort _serialConnection;

        private Func<HciMessage, Task> _onData;

        /// <summary>
        /// Initializes a new instance of the <see cref="IM871ADongle"/> class.
        /// </summary>
        /// <param name="options">the options.</param>
        /// <param name="loggerFactory">a logger factory.</param>
        public IM871ADongle(IOptions<ConfigurationOptions> options, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<IM871ADongle>();

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
            byte controlField = 0b1000;
            var endpointId = (byte)message.EndpointIdentifier;

            var combinedControlFieldAndEndPointId = (byte)((controlField << 4) | endpointId);

            var bytes = new List<byte>() { combinedControlFieldAndEndPointId, message.MessageIdentifier };

            IList<byte> payload = message.Payload;

            if (payload?.Count > 0)
            {
                var length = checked((byte)payload.Count);
                bytes.Add(length);
                bytes.AddRange(payload);
            }
            else
            {
                bytes.Add(0x00);
            }

            bytes.AppendCrc();
            bytes.Insert(0, StartOfFrame);
            Console.WriteLine(bytes.ToHexString());

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
            var readBytesCount = await stream.ReadAsync(buffer, 0, 4);

            if (readBytesCount > 0)
            {
                var controlField = buffer[1].GetHighNibble();
                var endpointId = buffer[1].GetLowNibble();

                var messageId = buffer[2];
                var length = buffer[3];
                var payload = new byte[2];

                var timestampPresent = controlField.GetBit(2);
                var rssiPresent = controlField.GetBit(3);
                var crcPresent = controlField.GetBit(4);

                if (timestampPresent)
                {
                    length += 4; // 32bit
                }

                if (rssiPresent)
                {
                    length += 1; // 8bit
                }

                if (crcPresent)
                {
                    length += 2; // 16bit
                }

                if (length > 0)
                {
                    await stream.ReadAsync(buffer, 0, length);

                    // +2 because we need to fit the endpoint id and message id in to it.
                    payload = new byte[length + 2];
                    Buffer.BlockCopy(buffer, 3, payload, 2, length);
                }

                payload[0] = (byte)endpointId;
                payload[1] = messageId;

                if (crcPresent)
                {
                    var valid = payload.ValidateCrc();

                    if (!valid)
                    {
                        throw new InvalidDataException("Wrong CRC16 checksum");
                    }
                }

                await _onData((HciMessage)ReceivableMessageFactory.Create(payload));
            }
        }
    }
}