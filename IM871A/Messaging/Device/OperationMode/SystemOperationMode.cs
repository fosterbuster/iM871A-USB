// <copyright file="SystemOperationMode.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

namespace IM871A.Messaging.Device.OperationMode
{
    /// <summary>
    /// System Operation Modes.
    /// </summary>
    public enum SystemOperationMode : byte
    {
        /// <summary>
        /// Standard Application Mode / Default Mode
        /// </summary>
        Default = 0x00,

        /// <summary>
        /// Hardware Test Mode for special test purposes
        /// </summary>
        HardwareTest = 0x01,
    }
}