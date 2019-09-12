// <copyright file="ConfigurationOptions.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace IM871A.DependencyInjection
{
    /// <summary>
    /// Configuration options.
    /// </summary>
    public class ConfigurationOptions
    {
        /// <summary>
        /// Gets or sets the name of the serial port.
        /// </summary>
        public string PortName { get; set; }

        /// <summary>
        /// Gets or sets the baud rate of the serial port.
        /// </summary>
        public int BaudRate { get; set; } = 57600;
    }
}