// <copyright file="ResetResponse.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace FosterBuster.IM871A.Messaging.Device
{
    /// <summary>
    /// This message can be used to reset the WM-Bus Module. The reset will be performed after approx. 500ms.
    /// </summary>
    public class ResetResponse : DeviceMessage, IReceivable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResetResponse"/> class.
        /// </summary>
        /// <param name="payload">the payload.</param>
        public ResetResponse(byte[] payload)
            : base(DeviceManagementMessageIdentifier.ResetResponse, payload)
        {
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "Reset Response.";
        }
    }
}