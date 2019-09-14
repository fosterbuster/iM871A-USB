// <copyright file="GetOperationModeRequest.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

namespace FosterBuster.IM871A.Messaging.Device.OperationMode
{
    /// <summary>
    /// This message is used to read the current System Operation Mode.
    /// </summary>
    public class GetOperationModeRequest : DeviceMessage, ITransmittable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetOperationModeRequest"/> class.
        /// </summary>
        public GetOperationModeRequest()
            : base(DeviceManagementMessageIdentifier.GetOperationModeRequest, null)
        {
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "GetOperationMode Request.";
        }
    }
}