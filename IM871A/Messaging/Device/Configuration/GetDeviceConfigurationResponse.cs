// <copyright file="GetDeviceConfigurationResponse.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Linq;
using FosterBuster.Extensions;
using FosterBuster.IM871A.Messaging.Device.Information;

namespace FosterBuster.IM871A.Messaging.Device.Configuration
{
    /// <summary>
    /// This message acknowledges the Get Config Request message.
    /// </summary>
    public class GetDeviceConfigurationResponse : DeviceMessage, IReceivable
    {
        private int _deviceModeIndex = -1;
        private int _radioModeIndex = -1;
        private int _wmBusCFieldIndex = -1;
        private int _wmBusManufacturerIdIndex = -1;
        private int _wmBusDeviceIdIndex = -1;
        private int _wmBusVersionIndex = -1;
        private int _wmbusDeviceTypeIndex = -1;
        private int _radioChannelIndex = -1;

        private int _radioPowerLevelIndex = -1;
        private int _radioDataRateIndex = -1;
        private int _radioRxWindowIndex = -1;
        private int _autoPowerSavingIndex = -1;
        private int _autoRssiAttachmentIndex = -1;
        private int _autoRxTimestampAttachmentIndex = -1;
        private int _ledControlIndex = -1;
        private int _rtcControlIndex = -1;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetDeviceConfigurationResponse"/> class.
        /// </summary>
        /// <param name="payload">the payload.</param>
        public GetDeviceConfigurationResponse(byte[] payload)
            : base(DeviceManagementMessageIdentifier.GetConfigurationResponse, payload)
        {
            if (payload.Length > 0)
            {
                CalculateIndexes();
            }
        }

        /// <summary>
        /// Gets the device  mode.
        /// </summary>
        public DeviceMode? DeviceMode => GetFromPayload<DeviceMode>(_deviceModeIndex);

        /// <summary>
        /// Gets the radio mode.
        /// </summary>
        public RadioMode? RadioMode => GetFromPayload<RadioMode>(_radioModeIndex);

        /// <summary>
        /// Gets the C Field, used in WM-Bus Radio Messages.
        /// </summary>
        public byte? WmBusCField => GetFromPayload<byte>(_wmBusCFieldIndex);

        /// <summary>
        /// Gets the Manufacturer ID, used in WM-Bus Radio Messages. (Readonly for USB).
        /// </summary>
        public byte[] WmBusManufacturerId => GetManufacturerId();

        /// <summary>
        /// Gets the Device ID, used in WM-Bus Radio Messages. (Readonly for USB).
        /// </summary>
        public byte[] WmBusDeviceId => GetDeviceId();

        /// <summary>
        /// Gets the Version, used in WM-Bus Radio Messages (Readonly for USB).
        /// </summary>
        public byte? WmBusVersion => GetFromPayload<byte>(_wmBusVersionIndex);

        /// <summary>
        /// Gets the Device Type, used in WM-Bus Radio Messages (Readonly for USB).
        /// </summary>
        public byte? WmBusDeviceType => GetFromPayload<byte>(_wmbusDeviceTypeIndex);

        /// <summary>
        /// Gets the radio channel.
        /// </summary>
        public RadioChannel? RadioChannel => GetFromPayload<RadioChannel>(_radioChannelIndex);

        /// <summary>
        /// Gets the radio power level in dBm.
        /// </summary>
        public int? RadioPowerLevel => GetRadioPowerLevel();

        /// <summary>
        /// Gets the Reception Window [ms] after Transmit.
        /// </summary>
        /// <remarks>
        /// The module will listen for radio messages for the given time before it enters a power saving state.This parameter is useful especially for battery powered devices (Meters) which are configured for bidirectional Radio communication (S2, T2, R2, C2, N2x).
        /// </remarks>
        public TimeSpan? RadioReceiveWindow => GetRadioRxWindow();

        /// <summary>
        /// Gets a value indicating whether or not the device has automatic power saving enabled.
        /// </summary>
        /// <remarks>
        /// If true device enters power saving mode after message transmission(S1, S1-m, T1, C1, N1x), reception or when the Radio Rx-Window terminates(S2, T2, R2, C2, N2x).
        /// </remarks>
        public bool? AutomaticPowerSaving => GetBoolOrNull(_autoPowerSavingIndex);

        /// <summary>
        /// Gets a value indicating wether the device will automatically output RSSI for each received Radio Message.
        /// </summary>
        public bool? AutomaticRssiAttachment => GetBoolOrNull(_autoRssiAttachmentIndex);

        /// <summary>
        /// Gets a value indicating wether the device will automatically output a timestamp for each received Radio Message.
        /// </summary>
        public bool? AutoReceiveTimestampAttachment => GetBoolOrNull(_autoRxTimestampAttachmentIndex);

        // TODO: Implement LED control.

        /// <summary>
        /// Gets a value indicating whether the device has RTC Control enabled or not.
        /// </summary>
        public bool? RtcControl => GetBoolOrNull(_rtcControlIndex);

        private bool? GetBoolOrNull(int index)
        {
            var val = GetFromPayload<byte?>(index);

            if (val.HasValue)
            {
                return val != 0x00;
            }

            return null;
        }

        private TimeSpan? GetRadioRxWindow()
        {
            var val = GetFromPayload<byte?>(_radioRxWindowIndex);

            if (val.HasValue)
            {
                return TimeSpan.FromMilliseconds(val.Value);
            }

            return null;
        }

        private void CalculateIndexes()
        {
            int cursor = 4;
            var iiflag1 = Payload[3];

            var deviceModePresent = iiflag1.GetBit(0);
            var radioModePresent = iiflag1.GetBit(1);
            var wmBusCFieldPresent = iiflag1.GetBit(2);
            var wmBusManufacturerIdPresent = iiflag1.GetBit(3);
            var wmBusDeviceIdPresent = iiflag1.GetBit(4);
            var wmBusVersionPresent = iiflag1.GetBit(5);
            var wmbusDeviceTypePresent = iiflag1.GetBit(6);
            var radioChannelPresent = iiflag1.GetBit(7);

            if (deviceModePresent)
            {
                _deviceModeIndex = cursor++;
            }

            if (radioModePresent)
            {
                _radioModeIndex = cursor++;
            }

            if (wmBusCFieldPresent)
            {
                _wmBusCFieldIndex = cursor++;
            }

            if (wmBusManufacturerIdPresent)
            {
                _wmBusManufacturerIdIndex = cursor;
                cursor += 2;
            }

            if (wmBusDeviceIdPresent)
            {
                _wmBusDeviceIdIndex = cursor;
                cursor += 4;
            }

            if (wmBusVersionPresent)
            {
                _wmBusVersionIndex = cursor++;
            }

            if (wmbusDeviceTypePresent)
            {
                _wmbusDeviceTypeIndex = cursor++;
            }

            if (radioChannelPresent)
            {
                _radioChannelIndex = cursor++;
            }

            var iiflag2 = Payload[cursor++];

            var radioPowerLevelPresent = iiflag2.GetBit(0);
            var radioDataRatePresent = iiflag2.GetBit(1);
            var radioRxWindowPresent = iiflag2.GetBit(2);
            var autoPowerSavingPresent = iiflag2.GetBit(3);
            var autoRssiAttachmentPresent = iiflag2.GetBit(4);
            var autoRxTimestampAttachmentPresent = iiflag2.GetBit(5);
            var ledControlPresent = iiflag2.GetBit(6);
            var rtcControlPresent = iiflag2.GetBit(7);

            if (radioPowerLevelPresent)
            {
                _radioPowerLevelIndex = cursor++;
            }

            if (radioDataRatePresent)
            {
                _radioDataRateIndex = cursor++;
            }

            if (radioRxWindowPresent)
            {
                _radioRxWindowIndex = cursor++;
            }

            if (autoPowerSavingPresent)
            {
                _autoPowerSavingIndex = cursor++;
            }

            if (autoRssiAttachmentPresent)
            {
                _autoRssiAttachmentIndex = cursor++;
            }

            if (autoRxTimestampAttachmentPresent)
            {
                _autoRxTimestampAttachmentIndex = cursor++;
            }

            if (ledControlPresent)
            {
                _ledControlIndex = cursor++;
            }

            if (rtcControlPresent)
            {
                _rtcControlIndex = cursor;
            }
        }

        private T GetFromPayload<T>(int index)
        {
            return index != -1 ? (T)(object)Payload[index] : default;
        }

        private byte[] GetManufacturerId()
        {
            var index = _wmBusManufacturerIdIndex;
            if (index == -1)
            {
                return new byte[0];
            }

            return Payload.Skip(index).Take(2).ToArray();
        }

        private byte[] GetDeviceId()
        {
            var index = _wmBusDeviceIdIndex;
            if (index == -1)
            {
                return new byte[0];
            }

            return Payload.Skip(index).Take(4).Reverse().ToArray();
        }

        private int? GetRadioPowerLevel()
        {
            var val = GetFromPayload<byte?>(_radioPowerLevelIndex);
            if (!val.HasValue)
            {
                return null;
            }

            return val switch
            {
                0 => -8,
                1 => -5,
                2 => -2,
                3 => 1,
                4 => 4,
                5 => 7,
                6 => 10,
                7 => 14,
                _ => throw new Exception("Unknown Radio Power Level"),
            };
        }

        public override string ToString()
        {
            return $"{{{nameof(DeviceMode)}={DeviceMode}, {nameof(RadioMode)}={RadioMode}, {nameof(WmBusCField)}={WmBusCField}, {nameof(WmBusManufacturerId)}={WmBusManufacturerId}, {nameof(WmBusDeviceId)}={WmBusDeviceId}, {nameof(WmBusVersion)}={WmBusVersion}, {nameof(WmBusDeviceType)}={WmBusDeviceType}, {nameof(RadioChannel)}={RadioChannel}, {nameof(RadioPowerLevel)}={RadioPowerLevel}, {nameof(RadioReceiveWindow)}={RadioReceiveWindow}, {nameof(AutomaticPowerSaving)}={AutomaticPowerSaving}, {nameof(AutomaticRssiAttachment)}={AutomaticRssiAttachment}, {nameof(AutoReceiveTimestampAttachment)}={AutoReceiveTimestampAttachment}, {nameof(RtcControl)}={RtcControl}, {nameof(MessageIdentifier)}={MessageIdentifier}, {nameof(EndpointIdentifier)}={EndpointIdentifier}, {nameof(Payload)}={Payload}, {nameof(MessageIdentifier)}={MessageIdentifier}}}";
        }
    }
}