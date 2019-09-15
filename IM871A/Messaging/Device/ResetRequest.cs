// <copyright file="ResetRequest.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

namespace FosterBuster.IM871A.Messaging.Device
{
    /// <summary>
    /// This message can be used to reset the WM-Bus Module. The reset will be performed afterapprox. 500ms.
    /// </summary>
    public class ResetRequest : DeviceMessage, ITransmittable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResetRequest"/> class.
        /// </summary>
        public ResetRequest()
            : base(DeviceManagementMessageIdentifier.ResetRequest, null)
        {
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "Reset Request.";
        }
    }
}