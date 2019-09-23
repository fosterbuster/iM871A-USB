// <copyright file="WMBusDataRequest.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using FosterBuster.Extensions;

namespace FosterBuster.IM871A.Messaging.Radio
{
    /// <summary>
    /// Request.
    /// This message can be used to send data as an M-Bus message via radio link.
    /// The first octet of the HCI payload is expected to be the CI- Field of the M-Bus message.The M-Bus Header Fields (C-Field, M-Field and A-Field) are taken from the configuration memory and can be modified via Device Configuration.
    /// The CRC16 of each M-Bus block and the M-Bus Length Field will be calculated and inserted by the firmware itself.
    /// </summary>
    public class WMBusDataRequest : RadioLinkMessage, ITransmittable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WMBusDataRequest"/> class.
        /// </summary>
        /// <param name="payload">WM-Bus message, starting with C Field.</param>
        public WMBusDataRequest(byte[] payload)
            : base(RadioLinkMessageIdentifier.MessageDataRequest, new List<byte>())
        {
            Payload.AddRange(payload);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "WMBus Data Request.";
        }
    }
}