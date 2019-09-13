// <copyright file="ToggleAesEncryptionRequest.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

namespace IM871A.Messaging.Device.Encryption
{
    /// <summary>
    /// This message can be used to enable the automatic AES-128 encryption. This message allows to change the AES encryption state directly and to save it optionally in the non-volatile flash memory.
    /// </summary>
    public class ToggleAesEncryptionRequest : DeviceMessage, ITransmittable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToggleAesEncryptionRequest"/> class.
        /// </summary>
        /// <param name="saveToMemory">A value indicating whether to change configuration only temporary or save configuration also in NVM.</param>
        /// <param name="enableAesEncryption">A value indicating whether to enable or disable AES128 encryption.</param>
        public ToggleAesEncryptionRequest(bool saveToMemory, bool enableAesEncryption)
            : base(DeviceManagementMessageIdentifier.EnableAesEncryptionKeyRequest, null)
        {
            Payload.Add(saveToMemory ? (byte)0x01 : (byte)0x00);
            Payload.Add(enableAesEncryption ? (byte)0x01 : (byte)0x00);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "Toggle AES Encryption Request.";
        }
    }
}