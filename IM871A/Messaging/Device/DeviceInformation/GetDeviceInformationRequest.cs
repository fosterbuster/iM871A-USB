// <copyright file="GetDeviceInformationRequest.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace IM871A.Messaging.Device.DeviceInformation
{
    /// <summary>
    /// The WM-Bus Firmware provides a service to readout some information elements for identification purposes. This service can be used to identify the local connected device. As a result the device sends a response message which contains information about the device.
    /// </summary>
    public class GetDeviceInformationRequest : DeviceMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetDeviceInformationRequest"/> class.
        /// </summary>
        public GetDeviceInformationRequest()
            : base(DeviceManagementMessageIdentifier.GetDeviceInformationRequest, null)
        {
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Get Device Information Request. {{{nameof(MessageIdentifier)}={MessageIdentifier}, {nameof(EndpointIdentifier)}={EndpointIdentifier}, {nameof(Payload)}={Payload}, {nameof(MessageIdentifier)}={MessageIdentifier}}}";
        }
    }
}