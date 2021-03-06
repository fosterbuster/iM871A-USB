﻿using System;
using System.Threading.Tasks;
using FosterBuster.IM871A;
using FosterBuster.IM871A.DependencyInjection;
using FosterBuster.IM871A.Messaging;
using FosterBuster.IM871A.Messaging.Device.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Example
{
    internal class Program
    {
#pragma warning disable IDE0060
        internal static async Task Main(string[] args)
        {
#pragma warning restore IDE0060
            ServiceProvider serviceCollection = new ServiceCollection().AddIM871ADongle(x =>
            {
                x.PortName = "COM4";
            })
           .AddSingleton<ILoggerFactory, LoggerFactory>()
           .AddLogging(loggingBuilder => loggingBuilder
           .AddConsole()
           .SetMinimumLevel(LogLevel.Trace))
           .BuildServiceProvider();

            ILogger<Program> logger = serviceCollection.GetService<ILoggerFactory>().CreateLogger<Program>();

            IM871ADongle modem = serviceCollection.GetService<IM871ADongle>();
            modem.AddReceiver(Test);
            await modem.TransmitMessage(new GetDeviceConfigurationRequest());
            Console.ReadKey();
        }

        private static async Task Test(HciMessage arg)
        {
            Console.WriteLine(arg);
            //Console.WriteLine("got it!");
            await Task.CompletedTask;
        }
    }
}
