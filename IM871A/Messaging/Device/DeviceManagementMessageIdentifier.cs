// <copyright file="DeviceManagementMessageIdentifier.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace IM871A.Messaging.Device
{
    /// <summary>
    /// Device management message identifiers.
    /// </summary>
    public enum DeviceManagementMessageIdentifier : byte
    {
        /// <summary>
        /// Ping Request
        /// </summary>
        PingRequest = 0x01,

        /// <summary>
        /// Ping Response
        /// </summary>
        PingResponse = 0x02,

        /// <summary>
        /// Set Configuration Request
        /// </summary>
        SetConfigurationRequest = 0x03,

        /// <summary>
        /// Set Configuration Response
        /// </summary>
        SetConfigurationResponse = 0x04,

        /// <summary>
        /// Get Configuration Request
        /// </summary>
        GetConfigurationRequest = 0x05,

        /// <summary>
        /// Get Configuration Response
        /// </summary>
        GetConfigurationResponse = 0x06,

        /// <summary>
        /// Reset Request
        /// </summary>
        ResetRequest = 0x07,

        /// <summary>
        /// Reset Response
        /// </summary>
        ResetResponse = 0x08,

        /// <summary>
        /// Factory Reset Request
        /// </summary>
        FactoryResetRequest = 0x09,

        /// <summary>
        /// Factory Reset Response
        /// </summary>
        FactoryResetResponse = 0x0A,

        /// <summary>
        /// Get Operation Mode Request
        /// </summary>
        GetOperationModeRequest = 0x0B,

        /// <summary>
        /// Get Operation Mode Response
        /// </summary>
        GetOperationModeResponse = 0x0C,

        /// <summary>
        /// Set Operation Mode Request
        /// </summary>
        SetOperationModeRequest = 0x0D,

        /// <summary>
        /// Set Operation Mode Response
        /// </summary>
        SetOperationModeResponse = 0x0E,

        /// <summary>
        /// Get Device Information Request
        /// </summary>
        GetDeviceInformationRequest = 0x0F,

        /// <summary>
        /// Get Device Information Response
        /// </summary>
        GetDeviceInformationResponse = 0x10,

        /// <summary>
        /// Get System Status Request
        /// </summary>
        GetSystemStatusRequest = 0x11,

        /// <summary>
        /// Get System Status Response
        /// </summary>
        GetSystemStatusResponse = 0x12,

        /// <summary>
        /// Get Firmware Information Request
        /// </summary>
        GetFirmwareInformationRequest = 0x13,

        /// <summary>
        /// Get Firmware Information Response
        /// </summary>
        GetFirmwareInformationResponse = 0x14,

        /// <summary>
        /// Get RTC Time Request
        /// </summary>
        GetRtcTimeRequest = 0x19,

        /// <summary>
        /// Get RTC Time Response
        /// </summary>
        GetRtcTimeResponse = 0x1A,

        /// <summary>
        /// Set RTC Time Request
        /// </summary>
        SetRtcTimeRequest = 0x1B,

        /// <summary>
        /// Set RTC Time Response
        /// </summary>
        SetRtcTimeResponse = 0x1C,

        /// <summary>
        /// Enter Low Power Mode Request
        /// </summary>
        EnterLowPowerModeRequest = 0x1D,

        /// <summary>
        /// Enter Low Power Mode Response
        /// </summary>
        EnterLowPowerModeResponse = 0x1E,

        /// <summary>
        /// Set AES Encryption Key Request
        /// </summary>
        SetAesEncryptionKeyRequest = 0x21,

        /// <summary>
        /// Set AES Encryption Key Response
        /// </summary>
        SetAesEncryptionKeyResponse = 0x22,

        /// <summary>
        /// Enable AES Encryption Key Request
        /// </summary>
        EnableAesEncryptionKeyRequest = 0x23,

        /// <summary>
        /// Enable AES Encryption Key Response
        /// </summary>
        EnableAesEncryptionKeyResponse = 0x24,

        /// <summary>
        /// Set AES Decryption Key Request
        /// </summary>
        SetAesDecryptionKeyRequest = 0x25,

        /// <summary>
        /// Set AES Decryption Key Response
        /// </summary>
        SetAesDecryptionKeyResponse = 0x26,

        /// <summary>
        /// AES Decryption Error Indication
        /// </summary>
        AesDecryptionErrorIndication = 0x27,
    }
}