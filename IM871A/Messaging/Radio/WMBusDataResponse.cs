// <copyright file="WMBusDataResponse.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

namespace FosterBuster.IM871A.Messaging.Radio
{
    /// <summary>
    /// Response.
    /// This command can be used to send an M-Bus message containing header and payload via radio link.
    /// The first octet of the HCI payload is expected to be the C- Field of the M-Bus message.
    /// The CRC16 of each M-Bus Data Block and the M-Bus Length Field will be calculated and inserted by the firmware itself.
    /// </summary>
    public class WMBusDataResponse : RadioLinkMessage, IReceivable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WMBusDataResponse"/> class.
        /// </summary>
        /// <param name="payload">the payload.</param>
        public WMBusDataResponse(byte[] payload)
            : base(RadioLinkMessageIdentifier.MessageDataResponse, payload)
        {
        }

        /// <summary>
        /// Gets a value indicating whether or not the <see cref="WMBusMessageRequest"/> failed.
        /// </summary>
        public bool Failed => Payload[3] == 0x00;

        /// <inheritdoc/>
        public override string ToString()
        {
            return "WMBus Data Response.";
        }
    }
}