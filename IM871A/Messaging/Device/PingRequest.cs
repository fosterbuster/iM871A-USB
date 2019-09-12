// <copyright file="PingRequest.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace IM871A.Messaging.Device
{
    /// <summary>
    /// This command is used to check if the connected WM-Bus Module is alive. The sender should expect a Ping Response within a certain time interval.
    /// </summary>
    public class PingRequest : DeviceMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PingRequest"/> class.
        /// </summary>
        public PingRequest()
            : base(DeviceManagementMessageIdentifier.PingRequest, null)
        {
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "Ping Request.";
        }
    }
}