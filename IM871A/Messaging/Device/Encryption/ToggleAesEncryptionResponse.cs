// <copyright file="ToggleAesEncryptionResponse.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

namespace IM871A.Messaging.Device.Encryption
{
    /// <summary>
    /// This message can be used to enable the automatic AES-128 encryption. This message allows to change the AES encryption state directly and to save it optionally in the non-volatile flash memory.
    /// </summary>
    public class ToggleAesEncryptionResponse : DeviceMessage, IReceivable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToggleAesEncryptionResponse"/> class.
        /// </summary>
        /// <param name="payload">the payload.</param>
        public ToggleAesEncryptionResponse(byte[] payload)
            : base(DeviceManagementMessageIdentifier.EnableAesEncryptionKeyResponse, payload)
        {
        }

        /// <summary>
        /// Gets a value indicating whether or not the operation of enabling encryption failed.
        /// </summary>
        public bool Failed => Payload[2] == 0x00;

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Toggle AES Encryption Response. Failed: {Failed}";
        }
    }
}