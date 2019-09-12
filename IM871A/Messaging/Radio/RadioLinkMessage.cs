// <copyright file="RadioLinkMessage.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace IM871A.Messaging.Radio
{
    /// <summary>
    /// Baseclass for messages sent to the radio link endpoint.
    /// </summary>
    public abstract class RadioLinkMessage : HciMessage
    {
        private readonly RadioLinkMessageIdentifier _identifier;

        /// <summary>
        /// Initializes a new instance of the <see cref="RadioLinkMessage"/> class.
        /// </summary>
        /// <param name="identifier">the radio link message identifier.</param>
        /// <param name="payload">the payload.</param>
        protected RadioLinkMessage(RadioLinkMessageIdentifier identifier, List<byte> payload)
            : base(EndpointIdentifier.RadioLink, payload)
        {
            _identifier = identifier;
        }

        /// <inheritdoc/>
        public override byte MessageIdentifier => (byte)_identifier;
    }
}