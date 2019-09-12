// <copyright file="ModuleType.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

namespace IM871A.Messaging.Device.DeviceInformation
{
    /// <summary>
    /// Identifies the Radio Module.
    /// </summary>
    public enum ModuleType : byte
    {
        /// <summary>
        /// iM871A
        /// </summary>
        IM871A = 0x33,

        /// <summary>
        /// iM170A
        /// </summary>
        IM170A = 0x36,
    }
}