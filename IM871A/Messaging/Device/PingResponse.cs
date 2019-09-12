// <copyright file="PingResponse.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace IM871A.Messaging.Device
{
    /// <summary>
    /// This command is used to check if the connected WM-Bus Module is alive. The sender should expect a Ping Response within a certain time interval.
    /// </summary>
    public class PingResponse : DeviceMessage, IReceivable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PingResponse"/> class.
        /// </summary>
        /// <param name="payload">the payload.</param>
        public PingResponse(byte[] payload)
            : base(DeviceManagementMessageIdentifier.PingResponse, payload)
        {
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "Ping Response.";
        }
    }
}