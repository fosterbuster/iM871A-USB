// <copyright file="SetOperationModeRequest.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace FosterBuster.IM871A.Messaging.Device.OperationMode
{
    /// <summary>
    /// This message sets the next System Operation Mode and performs a firmware reset.
    /// </summary>
    public class SetOperationModeRequest : DeviceMessage, ITransmittable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SetOperationModeRequest"/> class.
        /// </summary>
        /// <param name="systemOperationMode">The operation mode to set the device to.</param>
        public SetOperationModeRequest(SystemOperationMode systemOperationMode)
            : base(DeviceManagementMessageIdentifier.SetOperationModeRequest, new List<byte>())
        {
            Payload.Add((byte)systemOperationMode);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "SetOperationMode Request.";
        }
    }
}