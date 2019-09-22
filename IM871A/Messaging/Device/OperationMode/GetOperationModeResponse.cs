// <copyright file="GetOperationModeResponse.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

namespace FosterBuster.IM871A.Messaging.Device.OperationMode
{
    /// <summary>
    /// This message is used to read the current System Operation Mode.
    /// </summary>
    public class GetOperationModeResponse : DeviceMessage, IReceivable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetOperationModeResponse"/> class.
        /// </summary>
        /// <param name="payload">the payload.</param>
        public GetOperationModeResponse(byte[] payload)
            : base(DeviceManagementMessageIdentifier.GetOperationModeResponse, payload)
        {
        }

        /// <summary>
        /// Gets the current System Operation Mode.
        /// </summary>
        public SystemOperationMode SystemOperationMode => (SystemOperationMode)Payload[3];

        /// <inheritdoc/>
        public override string ToString()
        {
            // TODO: ToString();
            return "Get Operation Mode Response.";
        }
    }
}