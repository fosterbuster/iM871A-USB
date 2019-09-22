// <copyright file="WMBusMessageIndication.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Linq;

namespace FosterBuster.IM871A.Messaging.Radio
{
    /// <summary>
    /// Indication.
    /// Whenever the module receives an M-Bus message over the radio link, this message will be passed to the Host Controller.
    /// The included CRC Fields of the M-Bus message will be removed automatically and only the M-Bus Header and Data Blocks will be transmitted.
    /// </summary>
    public class WMBusMessageIndication : RadioLinkMessage, IReceivable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WMBusMessageIndication"/> class.
        /// </summary>
        /// <param name="payload">the payload.</param>
        public WMBusMessageIndication(byte[] payload)
            : base(RadioLinkMessageIdentifier.WMBusMessageIndication, payload)
        {
        }

        /// <summary>
        /// Gets the WMBus part of the payload.
        /// </summary>
        public byte[] WMBusPayload => GetWMBusPayload();

        /// <inheritdoc/>
        public override string ToString()
        {
            return "WMBus Message Indication Response.";
        }

        private byte[] GetWMBusPayload()
        {
            return Payload.Skip(3).ToArray();
        }
    }
}