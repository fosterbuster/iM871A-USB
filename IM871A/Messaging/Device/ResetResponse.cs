﻿// <copyright file="ResetResponse.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace IM871A.Messaging.Device
{
    /// <summary>
    /// This message can be used to reset the WM-Bus Module. The reset will be performed after approx. 500ms.
    /// </summary>
    public class ResetResponse : DeviceMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResetResponse"/> class.
        /// </summary>
        public ResetResponse()
            : base(DeviceManagementMessageIdentifier.ResetRequest, null)
        {
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "Reset Response.";
        }
    }
}