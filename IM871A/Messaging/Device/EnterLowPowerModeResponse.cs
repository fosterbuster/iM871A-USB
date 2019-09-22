// <copyright file="EnterLowPowerModeResponse.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

namespace FosterBuster.IM871A.Messaging.Device
{
    /// <summary>
    /// In addition to the automatic power saving feature the firmware provides a command to enter the low power mode.The LPM mode will be left with every new HCI message.
    /// </summary>
    public class EnterLowPowerModeResponse : DeviceMessage, IReceivable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnterLowPowerModeResponse"/> class.
        /// </summary>
        /// <param name="payload">the payload.</param>
        public EnterLowPowerModeResponse(byte[] payload)
            : base(DeviceManagementMessageIdentifier.EnterLowPowerModeResponse, payload)
        {
        }

        /// <summary>
        /// Gets a value indicating whether or not the operation failed.
        /// </summary>
        public bool Failed => Payload[3] == 0x00;

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Enter Low Power Mode Response. Failed: {Failed}";
        }
    }
}