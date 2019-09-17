using System;
using System.Threading.Tasks;
using FosterBuster.Extensions;
using FosterBuster.IM871A;
using FosterBuster.IM871A.DependencyInjection;
using FosterBuster.IM871A.Messaging;
using FosterBuster.IM871A.Messaging.Device;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Example
{
    internal class Program
    {
        internal static async Task Main(string[] args)
        {
            var bytes = new byte[] { 0x81, 0x02, 0x00, 0x4C, 0xA3 };

            var hmm = bytes.ValidateCrc();

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
            modem.SetReceiver(Test);
            await modem.TransmitMessage(new PingRequest());
            Console.ReadKey();
        }

        private async static Task Test(HciMessage arg)
        {
            Console.WriteLine(arg);
            //Console.WriteLine("got it!");
            await Task.CompletedTask;
        }
    }
}
