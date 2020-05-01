using System;
using System.Threading.Tasks;
using NServiceBus;

namespace Subscriber2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var endpointConfiguration = new EndpointConfiguration("subscriber2");
            endpointConfiguration.EnableInstallers();
            var transport = endpointConfiguration.UseTransport<SqsTransport>();

            var assemblyScanner = endpointConfiguration.AssemblyScanner();
            assemblyScanner.ExcludeTypes(typeof(MyOtherEventHandler));

            var endpoint = await Endpoint.Start(endpointConfiguration);
            Console.ReadLine();
        }
    }
}
