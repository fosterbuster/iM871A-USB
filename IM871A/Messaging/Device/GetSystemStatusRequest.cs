// <copyright file="GetSystemStatusRequest.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

namespace FosterBuster.IM871A.Messaging.Device
{
    /// <summary>
    /// This message is used to read the system status.
    /// </summary>
    public class GetSystemStatusRequest : DeviceMessage, ITransmittable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSystemStatusRequest"/> class.
        /// </summary>
        public GetSystemStatusRequest()
            : base(DeviceManagementMessageIdentifier.GetSystemStatusRequest, null)
        {
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "GetSystemStatus Request.";
        }
    }
}