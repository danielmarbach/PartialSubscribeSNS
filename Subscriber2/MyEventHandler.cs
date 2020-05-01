using System;
using System.Threading.Tasks;
using Messages;
using NServiceBus;

namespace Subscriber2
{
    public class MyEventHandler : IHandleMessages<MyEvent>
    {
        public Task Handle(MyEvent message, IMessageHandlerContext context)
        {
            Console.WriteLine("Got MyEvent");
            return Task.CompletedTask;
        }
    }
}