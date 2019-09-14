using System;
using System.Threading.Tasks;
using FosterBuster.IM871A;
using FosterBuster.IM871A.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Example
{
    internal class Program
    {
        internal static async Task Main( string[] args )
        {
            ServiceProvider serviceCollection = new ServiceCollection().AddIM871ADongle(x =>
            {
                x.PortName = "USB";
            })
           .AddSingleton<ILoggerFactory, LoggerFactory>()
           .AddLogging(loggingBuilder => loggingBuilder
           .AddConsole()
           .SetMinimumLevel(LogLevel.Trace))
           .BuildServiceProvider();

            ILogger<Program> logger = serviceCollection.GetService<ILoggerFactory>().CreateLogger<Program>();

            logger.LogDebug("Starting WiMod.");
            IM871ADongle modem = serviceCollection.GetService<IM871ADongle>();
            await modem.TransmitMessage(null);
            Console.WriteLine();
        }
    }
}
