using System;
using System.Collections.Generic;
using System.Text;
using FosterBuster.IM871A.Messaging.Device.Information;

namespace FosterBuster.IM871A.Messaging.Device.Configuration
{
    public class SetDeviceConfigurationRequest : DeviceMessage, ITransmittable
    {
        public SetDeviceConfigurationRequest(DeviceMode deviceMode)
            : base(DeviceManagementMessageIdentifier.SetConfigurationRequest, new List<byte>())
        {
        }
    }
}