// <copyright file="DeviceMessage.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace IM871A.Messaging.Device
{
    /// <summary>
    /// Baseclass for messages sent to the device management endpoint.
    /// </summary>
    public abstract class DeviceMessage : HciMessage
    {
        private readonly DeviceManagementMessageIdentifier _identifier;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceMessage"/> class.
        /// </summary>
        /// <param name="identifier">the device management message identifier.</param>
        /// <param name="payload">the payload.</param>
        protected DeviceMessage(DeviceManagementMessageIdentifier identifier, List<byte> payload)
            : base(EndpointIdentifier.DeviceManagement, payload)
        {
            _identifier = identifier;
        }

        /// <inheritdoc/>
        public override byte MessageIdentifier => (byte)_identifier;
    }
}