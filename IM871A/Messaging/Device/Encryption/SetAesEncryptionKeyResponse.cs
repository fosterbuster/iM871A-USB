// <copyright file="SetAesEncryptionKeyResponse.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

namespace IM871A.Messaging.Device.Encryption
{
    /// <summary>
    /// This command is used to check if the connected WM-Bus Module is alive. The sender should expect a SetAesEncryptionKey Response within a certain time interval.
    /// </summary>
    public class SetAesEncryptionKeyResponse : DeviceMessage, IReceivable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SetAesEncryptionKeyResponse"/> class.
        /// </summary>
        /// <param name="payload">the payload.</param>
        public SetAesEncryptionKeyResponse(byte[] payload)
            : base(DeviceManagementMessageIdentifier.SetAesEncryptionKeyResponse, payload)
        {
        }

        /// <summary>
        /// Gets a value indicating whether or not the operation of setting the encryptionkey failed.
        /// </summary>
        public bool Failed => Payload[2] == 0x00;

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Set AES Encryption Key Response. Failed: {Failed}";
        }
    }
}