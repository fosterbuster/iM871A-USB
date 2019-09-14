// <copyright file="SetAesEncryptionKeyRequest.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using FosterBuster.Extensions;

namespace FosterBuster.IM871A.Messaging.Device.Encryption
{
    /// <summary>
    /// This function can be used to change the AES-128 encryption key which is used for packet transmission. The function allows to change the encryption key directly and to save it optionallyin the non-volatile flash memory.
    /// </summary>
    public class SetAesEncryptionKeyRequest : DeviceMessage, ITransmittable
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="SetAesEncryptionKeyRequest"/> class.
        /// </summary>
        /// <param name="saveToMemory">A value indicating whether to change configuration only temporary or save configuration also in NVM.</param>
        /// <param name="encryptionKey">AES-128 bit key.</param>
        public SetAesEncryptionKeyRequest(bool saveToMemory, IList<byte> encryptionKey)
            : base(DeviceManagementMessageIdentifier.SetAesEncryptionKeyRequest, new List<byte>())
        {
            var storeInNonVolatileMemoryFlag = saveToMemory ? (byte)0x01 : (byte)0x00;

            Payload.Add(storeInNonVolatileMemoryFlag);
            Payload.AddRange(encryptionKey);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "SetAesEncryptionKey Request.";
        }
    }
}