// <copyright file="SetDecryptionKeyResponse.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

namespace FosterBuster.IM871A.Messaging.Device.Decryption
{
    /// <summary>
    /// This function can be used to reset the WM-Bus Module configuration to its default factory settings. Please note that the new configuration is activated after reboot.
    /// </summary>
    public class SetDecryptionKeyResponse : DeviceMessage, IReceivable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SetDecryptionKeyResponse"/> class.
        /// </summary>
        /// <param name="payload">the payload.</param>
        public SetDecryptionKeyResponse(byte[] payload)
            : base(DeviceManagementMessageIdentifier.SetAesDecryptionKeyResponse, payload)
        {
        }

        /// <summary>
        /// Gets a value indicating whether or not the factory reset failed.
        /// </summary>
        public bool Failed => Payload[2] == 0x00;

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Set Decryption Key Response. Failed: {Failed}";
        }
    }
}