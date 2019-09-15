// <copyright file="FactoryResetRequest.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace FosterBuster.IM871A.Messaging.Device
{
    /// <summary>
    /// This function can be used to reset the WM-Bus Module configuration to its default factory settings. Please note that the new configuration is activated after reboot.
    /// </summary>
    public class FactoryResetRequest : DeviceMessage, ITransmittable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FactoryResetRequest"/> class.
        /// </summary>
        /// <param name="rebootDeviceAfterFactoryReset">a value indicating if the device should reboot after the factory reset.</param>
        public FactoryResetRequest(bool rebootDeviceAfterFactoryReset = true)
            : base(DeviceManagementMessageIdentifier.FactoryResetRequest, new List<byte>())
        {
            var rebootFlag = rebootDeviceAfterFactoryReset ? (byte)0x00 : (byte)0x01;
            Payload.Add(rebootFlag);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "Factory Reset Request.";
        }
    }
}