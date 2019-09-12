// <copyright file="SetDeviceConfigurationResponse.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace IM871A.Messaging.Device.Configuration
{
    /// <summary>
    /// This message acknowledges the Get Config Request message.
    /// </summary>
    public class SetDeviceConfigurationResponse : DeviceMessage, IReceivable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SetDeviceConfigurationResponse"/> class.
        /// </summary>
        /// <param name="payload">the payload.</param>
        public SetDeviceConfigurationResponse(byte[] payload)
            : base(DeviceManagementMessageIdentifier.SetConfigurationResponse, payload)
        {
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "Set Device Configuration Response";
        }
    }
}