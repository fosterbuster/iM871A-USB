// <copyright file="EnterLowPowerModeRequest.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace FosterBuster.IM871A.Messaging.Device
{
    /// <summary>
    /// In addition to the automatic power saving feature the firmware provides a command to enter the low power mode.The LPM mode will be left with every new HCI message.
    /// </summary>
    public class EnterLowPowerModeRequest : DeviceMessage, ITransmittable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnterLowPowerModeRequest"/> class.
        /// </summary>
        public EnterLowPowerModeRequest()
            : base(DeviceManagementMessageIdentifier.EnterLowPowerModeRequest, new List<byte>() { 0x00 })
        {
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "EnterLowPowerMode Request.";
        }
    }
}