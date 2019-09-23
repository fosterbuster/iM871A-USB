// <copyright file="WMBusMessageRequest.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using FosterBuster.Extensions;

namespace FosterBuster.IM871A.Messaging.Radio
{
    /// <summary>
    /// Request.
    /// This command can be used to send an M-Bus message containing header and payload via radio link.
    /// The first octet of the HCI payload is expected to be the C- Field of the M-Bus message.
    /// The CRC16 of each M-Bus Data Block and the M-Bus Length Field will be calculated and inserted by the firmware itself.
    /// </summary>
    public class WMBusMessageRequest : RadioLinkMessage, ITransmittable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WMBusMessageRequest"/> class.
        /// </summary>
        /// <param name="payload">WM-Bus message, starting with C Field.</param>
        public WMBusMessageRequest(byte[] payload)
            : base(RadioLinkMessageIdentifier.WMBusMessageRequest, new List<byte>())
        {
            Payload.AddRange(payload);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "WMBus Message Request.";
        }
    }
}