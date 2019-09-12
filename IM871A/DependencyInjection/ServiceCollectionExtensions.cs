﻿// <copyright file="ServiceCollectionExtensions.cs" company="Poul Erik Venø Hansen">
// Copyright (c) Poul Erik Venø Hansen. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System;
using Microsoft.Extensions.DependencyInjection;

namespace IM871A.DependencyInjection
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
        public static IServiceCollection AddIm871ADongle(this IServiceCollection services, Action<ConfigurationOptions> setupAction)
        {
            services.Configure(setupAction);
            services.AddSingleton<Im871ADongle>();
            return services;
        }
    }
}