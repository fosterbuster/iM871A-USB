using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using IM871A.DependencyInjection;
using IM871A;

namespace Example
{
    internal class Program
    {
        internal static async Task Main( string[] args )
        {
            ServiceProvider serviceCollection = new ServiceCollection().AddIm871ADongle(x =>
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
            Im871ADongle modem = serviceCollection.GetService<Im871ADongle>();
            Console.WriteLine();
        }
    }
}
