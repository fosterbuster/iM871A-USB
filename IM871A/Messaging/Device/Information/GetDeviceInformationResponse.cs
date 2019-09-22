// <copyright file="GetDeviceInformationResponse.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using FosterBuster.Extensions;

namespace FosterBuster.IM871A.Messaging.Device.Information
{
    /// <summary>
    /// The WM-Bus Firmware provides a service to readout some information elements for identification purposes. This service can be used to identify the local connected device. As a result the device sends a response message which contains information about the device.
    /// </summary>
    public class GetDeviceInformationResponse : DeviceMessage, IReceivable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetDeviceInformationResponse"/> class.
        /// </summary>
        /// <param name="payload">the payload.</param>
        public GetDeviceInformationResponse(byte[] payload)
            : base(DeviceManagementMessageIdentifier.GetDeviceInformationResponse, payload)
        {
        }

        /// <summary>
        /// Gets the module type, which identifies the Radio Module.
        /// </summary>
        public ModuleType ModuleType => (ModuleType)Payload[3];

        /// <summary>
        /// Gets a value which indicates the current Device Mode.
        /// </summary>
        public DeviceMode DeviceMode => (DeviceMode)Payload[4];

        /// <summary>
        /// Gets the firmware version.
        /// </summary>
        // Documentation says 0x13 = V1.3.. So I guess this is a way to do it.
        public double FirmwareVersion => double.Parse(Payload[5].ToString("X")) / 10;

        /// <summary>
        /// Gets the HCI Protocol Version.
        /// </summary>
        public byte HciProtocolVersion => Payload[6];

        /// <summary>
        /// Gets the Unique Device ID.
        /// </summary>
        public IList<byte> UniqueDeviceId => GetUniqueDeviceId();

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"GetDeviceInformationResponse {{{nameof(ModuleType)}={ModuleType}, {nameof(DeviceMode)}={DeviceMode}, {nameof(FirmwareVersion)}={FirmwareVersion}, {nameof(HciProtocolVersion)}={HciProtocolVersion}, {nameof(UniqueDeviceId)}={UniqueDeviceId.ToHexString()}, {nameof(MessageIdentifier)}={MessageIdentifier}, {nameof(EndpointIdentifier)}={EndpointIdentifier}, {nameof(Payload)}={Payload.ToHexString()}, {nameof(MessageIdentifier)}={MessageIdentifier}}}";
        }

        private IList<byte> GetUniqueDeviceId()
        {
            return Payload.Skip(7).Take(4).ToList();
        }
    }
}