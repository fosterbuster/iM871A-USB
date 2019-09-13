// <copyright file="SetDecryptionKeyRequest.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using IM871A.Utilities.Extensions;

namespace IM871A.Messaging.Device.Decryption
{
    /// <summary>
    /// This command is used to check if the connected WM-Bus Module is alive. The sender should expect a SetDecryptionKeyRequest Response within a certain time interval.
    /// </summary>
    public class SetDecryptionKeyRequest : DeviceMessage, ITransmittable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SetDecryptionKeyRequest"/> class.
        /// </summary>
        /// <param name="index">Index to insert the decryptionkey at. Valid values 0-15</param>
        /// <param name="manufacturerId">the mbus manufacturer id.</param>
        /// <param name="deviceId">the mbus device id.</param>
        /// <param name="versionId">the mbus version id.</param>
        /// <param name="deviceType">the mbus device-type.</param>
        /// <param name="decryptionKey">the AES-128 bit decryption key</param>
        public SetDecryptionKeyRequest(int index, byte[] manufacturerId, byte[] deviceId, byte versionId, byte deviceType, byte[] decryptionKey)
            : base(DeviceManagementMessageIdentifier.SetAesDecryptionKeyRequest, new List<byte>())
        {
            if (index < 0 || index > 15)
            {
                throw new ArgumentException("Invalid index-value. Maximum table capacity is 16 [0-15]");
            }

            Payload.Add((byte)index);
            Payload.AddRange(manufacturerId);
            Payload.AddRange(deviceId);
            Payload.Add(versionId);
            Payload.Add(deviceType);
            Payload.AddRange(decryptionKey);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "SetDecryptionKey Request.";
        }
    }
}