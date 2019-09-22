// <copyright file="RadioChannel.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

namespace FosterBuster.IM871A.Messaging.Device.Configuration
{
    /// <summary>
    /// Indicates which radio channel the device is operating on.
    /// </summary>
    public enum RadioChannel : byte
    {
        /// <summary>
        /// 868.09MHz (R-Mode)
        /// </summary>
        RMode868_09 = 0x01,

        /// <summary>
        /// 868.15MHz (R-Mode)
        /// </summary>
        RMode868_15 = 0x02,

        /// <summary>
        /// 868.21MHz (R-Mode)
        /// </summary>
        RMode868_21 = 0x03,

        /// <summary>
        /// 868.27MHz (R-Mode)
        /// </summary>
        RMode868_27 = 0x04,

        /// <summary>
        /// 868.33MHz (R-Mode)
        /// </summary>
        RMode868_33 = 0x05,

        /// <summary>
        /// 868.39MHz (R-Mode)
        /// </summary>
        RMode868_39 = 0x06,

        /// <summary>
        /// 868.45MHz (R-Mode)
        /// </summary>
        RMode868_45 = 0x07,

        /// <summary>
        /// 868.51MHz (R-Mode)
        /// </summary>
        RMode868_51 = 0x08,

        /// <summary>
        /// 868.57MHz (R-Mode)
        /// </summary>
        RMode868_57 = 0x09,

        /// <summary>
        /// 868.30MHz (S-Mode)
        /// </summary>
        SMode868_30 = 0x0A,

        /// <summary>
        /// 868.95MHz (T-Mode)
        /// </summary>
        TMode868_95 = 0x0B,
    }
}