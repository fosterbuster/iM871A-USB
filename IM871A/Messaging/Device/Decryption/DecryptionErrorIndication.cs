// <copyright file="DecryptionErrorIndication.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Linq;

namespace IM871A.Messaging.Device.Decryption
{
    /// <summary>
    /// This function can be used to reset the WM-Bus Module configuration to its default factory settings. Please note that the new configuration is activated after reboot.
    /// </summary>
    public class DecryptionErrorIndication : DeviceMessage, IReceivable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DecryptionErrorIndication"/> class.
        /// </summary>
        /// <param name="payload">the payload.</param>
        public DecryptionErrorIndication(byte[] payload)
            : base(DeviceManagementMessageIdentifier.AesDecryptionErrorIndication, payload)
        {
        }

        /// <summary>
        /// Gets the MBus Control Field of failing packet.
        /// </summary>
        public byte CField => Payload[2];

        /// <summary>
        /// Gets the MBus Control Field of the failing packet.
        /// </summary>
        public byte[] ManufacturerId => GetManufacturerId();

        /// <summary>
        /// Gets the MBus Device Id of the failing packet.
        /// </summary>
        public byte[] DeviceId => GetDeviceId();

        /// <summary>
        /// Gets the MBus Version Field of the failing packet.
        /// </summary>
        public byte Version => Payload[9];

        /// <summary>
        /// Gets the MBus DeviceType Field of the failing packet.
        /// </summary>
        public byte DeviceType => Payload[10];

        // FIXME: Make tostring.. Need to port mbus extensions for proper string representation of devices.

        private byte[] GetManufacturerId()
        {
            return Payload.Skip(3).Take(2).ToArray();
        }

        private byte[] GetDeviceId()
        {
            return Payload.Skip(5).Take(4).ToArray();
        }
    }
}