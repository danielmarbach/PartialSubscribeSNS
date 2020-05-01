using System;
using System.Threading.Tasks;
using NServiceBus;

namespace Subscriber1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var endpointConfiguration = new EndpointConfiguration("subscriber1");
            endpointConfiguration.EnableInstallers();

            var assemblyScanner = endpointConfiguration.AssemblyScanner();
            assemblyScanner.ExcludeTypes(typeof(MyEventHandler));

            var transport = endpointConfiguration.UseTransport<SqsTransport>();

            var endpoint = await Endpoint.Start(endpointConfiguration);
            Console.ReadLine();
        }
    }
}
