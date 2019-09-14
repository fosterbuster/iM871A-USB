// <copyright file="ServiceCollectionExtensions.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the GNU Affero General Public License v3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

using System;
using Microsoft.Extensions.DependencyInjection;

namespace FosterBuster.IM871A.DependencyInjection
{
    /// <summary>
    /// Extension methods for DI.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds dependencies for the iM871A Dongle.
        /// </summary>
        /// <param name="services">the service collection to be modified.</param>
        /// <param name="setupAction">an action for hooking into.</param>
        /// <returns>a modified service collection.</returns>
        public static IServiceCollection AddIM871ADongle(this IServiceCollection services, Action<ConfigurationOptions> setupAction)
        {
            services.Configure(setupAction);
            services.AddSingleton<IM871ADongle>();
            return services;
        }
    }
}