// <copyright file="HciMessage.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace IM871A.Messaging
{
    /// <summary>
    /// Baseclass for all messages.
    /// </summary>
    public abstract class HciMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HciMessage"/> class.
        /// </summary>
        /// <param name="identifier">the endpoint identifier.</param>
        /// <param name="payload">the payload.</param>
        protected HciMessage(EndpointIdentifier identifier, IList<byte> payload)
        {
            EndpointIdentifier = identifier;
            Payload = payload;
        }

        /// <summary>
        /// Gets the identifier of the endpoint this message should be sent to.
        /// </summary>
        public EndpointIdentifier EndpointIdentifier { get; private set; }

        /// <summary>
        /// Gets the payload of this message.
        /// </summary>
        public List<byte> Payload { get; private set; }

        /// <summary>
        /// Gets the message identifier.
        /// </summary>
        public abstract byte MessageIdentifier { get; }
    }
}