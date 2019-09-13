// <copyright file="EndpointIdentifier.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

namespace IM871A.Messaging
{
    /// <summary>
    /// Endpoint identifiers.
    /// </summary>
    public enum EndpointIdentifier : byte
    {
        /// <summary>
        /// Device Management Identifier.
        /// </summary>
        DeviceManagement = 0x01,

        /// <summary>
        /// Radio Link Identifer.
        /// </summary>
        RadioLink = 0x02,

        /// <summary>
        /// Radio Link Test Identifier.
        /// </summary>
        RadioLinkTest = 0x03,

        /// <summary>
        /// Hardware Test Identifier.
        /// </summary>
        HardwareTest = 0x04,
    }
}