using System;
using System.Threading.Tasks;
using Messages;
using NServiceBus;

namespace PartialSubscribeSNS
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var endpointConfiguration = new EndpointConfiguration("publisher");
            endpointConfiguration.EnableInstallers();
            var transport = endpointConfiguration.UseTransport<SqsTransport>();

            var endpoint = await Endpoint.Start(endpointConfiguration);

            Console.WriteLine("Hit enter to publish");
            Console.ReadLine();

            await endpoint.Publish(new MyEvent());
            await endpoint.Publish(new MyOtherEvent());
            Console.ReadLine();
        }
    }
}
