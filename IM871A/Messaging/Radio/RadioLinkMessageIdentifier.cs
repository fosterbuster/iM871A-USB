// <copyright file="RadioLinkMessageIdentifier.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

namespace IM871A.Messaging.Radio
{
    /// <summary>
    /// Radio link message identifiers.
    /// </summary>
    public enum RadioLinkMessageIdentifier : byte
    {
        /// <summary>
        /// Send WM-Bus message request.
        /// </summary>
        WMBusMessageRequest = 0x01,

        /// <summary>
        /// Send WM-Bus message response.
        /// </summary>
        WMBusMessageRespone = 0x02,

        /// <summary>
        /// WM-Bus message indication.
        /// </summary>
        WMBusMessageIndication = 0x03,

        /// <summary>
        /// Send data as WM-Bus message.
        /// </summary>
        MessageDataRequest = 0x04,

        /// <summary>
        /// Send data response.
        /// </summary>
        MessageDataResponse = 0x05,
    }
}