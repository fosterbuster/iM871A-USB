// <copyright file="GetSystemStatusResponse.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Linq;
using FosterBuster.Extensions;

namespace FosterBuster.IM871A.Messaging.Device
{
    /// <summary>
    /// This message is used to read the system status.
    /// </summary>
    public class GetSystemStatusResponse : DeviceMessage, IReceivable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSystemStatusResponse"/> class.
        /// </summary>
        /// <param name="payload">the payload.</param>
        public GetSystemStatusResponse(byte[] payload)
            : base(DeviceManagementMessageIdentifier.GetSystemStatusResponse, payload)
        {
        }

        /// <summary>
        /// Gets a value indicating whether or not Configuation Data is present.
        /// </summary>
        public bool ConfigurationDataIsConfigured => Payload[2].GetBit(0);

        /// <summary>
        /// Gets a value indicating whether or not Production Data is present.
        /// </summary>
        public bool ProductionDataIsConfigured => Payload[2].GetBit(1);

        /// <summary>
        /// Gets a value indicating whether or not AES Data is corrupt.
        /// </summary>
        public bool AesDataIsCorrupt => Payload[2].GetBit(2);

        /// <summary>
        /// Gets a value indicating whether or not the FFS (Fast File System) is corrupt.
        /// </summary>
        public bool FileSystemIsCorrupt => Payload[2].GetBit(7);

        /// <summary>
        /// Gets System Ticks with 10 ms resolution, updated continuously when the module is not in a power saving state.
        /// </summary>
        public int SystemTicks => BitConverter.ToInt32(Payload.Skip(5).Take(4).ToArray(), 0);

        /// <summary>
        /// Gets the number of transmitted radio messages.
        /// </summary>
        public int TransmittedFramesCount => BitConverter.ToInt32(Payload.Skip(16).Take(4).ToArray(), 0);

        /// <summary>
        /// Gets the number of not transmitted radio messages.
        /// </summary>
        public int TransmittedFramesErrorCount => BitConverter.ToInt32(Payload.Skip(20).Take(4).ToArray(), 0);

        /// <summary>
        /// Gets the number of received radio messages.
        /// </summary>
        public int ReceivedFramesCount => BitConverter.ToInt32(Payload.Skip(24).Take(4).ToArray(), 0);

        /// <summary>
        /// Gets the number of received CRC errors (radio link).
        /// </summary>
        public int ReceivedFramesCrcErrorCount => BitConverter.ToInt32(Payload.Skip(28).Take(4).ToArray(), 0);

        /// <summary>
        /// Gets the number of received decoding errors.
        /// </summary>

        // FIXME: wrong value. Might be skipping too little or too much.
        public int ReceivedFramesDecodeErrorCount => BitConverter.ToInt32(Payload.Skip(32).Take(4).ToArray(), 0);

        ///// <inheritdoc/>
        public override string ToString()
        {
            return $"Get System Status Response. {{{nameof(ConfigurationDataIsConfigured)}={ConfigurationDataIsConfigured}, {nameof(ProductionDataIsConfigured)}={ProductionDataIsConfigured}, {nameof(AesDataIsCorrupt)}={AesDataIsCorrupt}, {nameof(FileSystemIsCorrupt)}={FileSystemIsCorrupt}, {nameof(SystemTicks)}={SystemTicks}, {nameof(TransmittedFramesCount)}={TransmittedFramesCount}, {nameof(TransmittedFramesErrorCount)}={TransmittedFramesErrorCount}, {nameof(ReceivedFramesCount)}={ReceivedFramesCount}, {nameof(ReceivedFramesCrcErrorCount)}={ReceivedFramesCrcErrorCount}, {nameof(ReceivedFramesDecodeErrorCount)}={ReceivedFramesDecodeErrorCount}, {nameof(MessageIdentifier)}={MessageIdentifier}, {nameof(EndpointIdentifier)}={EndpointIdentifier}, {nameof(Payload)}={Payload}, {nameof(MessageIdentifier)}={MessageIdentifier}}}";
        }
    }
}