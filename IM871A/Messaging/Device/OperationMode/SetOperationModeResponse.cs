// <copyright file="SetOperationModeResponse.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

namespace FosterBuster.IM871A.Messaging.Device.OperationMode
{
    /// <summary>
    /// This function can be used to reset the WM-Bus Module configuration to its default factory settings. Please note that the new configuration is activated after reboot.
    /// </summary>
    public class SetOperationModeResponse : DeviceMessage, IReceivable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SetOperationModeResponse"/> class.
        /// </summary>
        /// <param name="payload">the payload.</param>
        public SetOperationModeResponse(byte[] payload)
            : base(DeviceManagementMessageIdentifier.SetOperationModeResponse, payload)
        {
        }

        /// <summary>
        /// Gets a value indicating whether or not the <see cref="SetOperationModeRequest"/> failed.
        /// </summary>
        public bool Failed => Payload[2] == 0x00;

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Set Operation Mode Response. Failed: {Failed}";
        }
    }
}