// <copyright file="ReceivableMessageFactory.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using FosterBuster.Extensions;

namespace FosterBuster.IM871A.Messaging
{
    internal static class ReceivableMessageFactory
    {
        private static readonly Dictionary<(byte endpointIdentifier, byte messageIdentifier), Type> _knownSubTypes = new Dictionary<(byte, byte), Type>();

        static ReceivableMessageFactory() => RegisterAllRxHciMessageTypes();

        public static IReceivable Create(IList<byte> payload)
        {
            if (_knownSubTypes.TryGetValue((endpointIdentifier: payload[0], messageIdentifier: payload[1]), out Type type))
            {
                return (IReceivable)Activator.CreateInstance(type, payload);
            }

            throw new KeyNotFoundException("Could not find a compatible message to marshal into. Please ensure the response message has been implemented.");
        }

        private static void RegisterAllRxHciMessageTypes()
        {
            Type receivableInterface = typeof(IReceivable);
            foreach (Type type in AppDomain.CurrentDomain.GetAssemblies().SelectMany(domainAssembly => domainAssembly.GetTypes()
                                  .Where(type => !type.IsAbstract && receivableInterface.IsAssignableFrom(type)).Select(type => type)))
            {
                var instance = (IReceivable)Activator.CreateInstance(type, new byte[] { });
                var endpointValue = (byte)type.GetProperty("EndpointIdentifier").GetValue(instance);
                var messageValue = (byte)type.GetProperty("MessageIdentifier").GetValue(instance);
                _knownSubTypes.Add((endpointIdentifier: endpointValue, messageIdentifier: messageValue), type);
            }
        }
    }
}