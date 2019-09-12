// <copyright file="FactoryResetResponse.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace IM871A.Messaging.Device
{
    /// <summary>
    /// This function can be used to reset the WM-Bus Module configuration to its default factory settings. Please note that the new configuration is activated after reboot.
    /// </summary>
    public class FactoryResetResponse : DeviceMessage, IReceivable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FactoryResetResponse"/> class.
        /// </summary>
        /// <param name="payload">the payload.</param>
        public FactoryResetResponse(byte[] payload)
            : base(DeviceManagementMessageIdentifier.FactoryResetResponse, payload)
        {
        }

        /// <summary>
        /// Gets a value indicating whether or not the factory reset failed.
        /// </summary>
        public bool Failed => Payload[2] == 0x00;

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Factory Reset Response. Failed: {Failed}";
        }
    }
}