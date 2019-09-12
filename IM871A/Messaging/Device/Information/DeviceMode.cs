// <copyright file="DeviceMode.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

namespace IM871A.Messaging.Device.Information
{
    /// <summary>
    /// Indicates the current Device Mode.
    /// </summary>
    public enum DeviceMode : byte
    {
        /// <summary>
        /// Other
        /// </summary>
        Other = 0x00,

        /// <summary>
        /// Meter
        /// </summary>
        Meter = 0x01,
    }
}