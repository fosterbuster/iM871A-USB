// <copyright file="Im871ADongle.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.IO.Ports;
using IM871A.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace IM871A
{
    /// <summary>
    /// Represents a physical iMST iM871A Dongle.
    /// </summary>
    public class Im871ADongle
    {
        private readonly ILogger<Im871ADongle> _logger;
        private readonly SerialPort _serialConnection;

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

        private void OnSerialDataAvailable(object sender, SerialDataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}