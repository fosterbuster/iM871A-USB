// <copyright file="GetDeviceConfigurationRequest.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

namespace FosterBuster.IM871A.Messaging.Device.Configuration
{
    /// <summary>
    /// This command is used to check if the connected WM-Bus Module is alive. The sender should expect a Ping Response within a certain time interval.
    /// </summary>
    public class GetDeviceConfigurationRequest : DeviceMessage, ITransmittable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetDeviceConfigurationRequest"/> class.
        /// </summary>
        public GetDeviceConfigurationRequest()
            : base(DeviceManagementMessageIdentifier.GetConfigurationRequest, new byte[0])
        {
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "Get Device Configuration Request.";
        }
    }
}