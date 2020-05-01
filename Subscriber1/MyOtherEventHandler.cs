using System;
using System.Threading.Tasks;
using Messages;
using NServiceBus;

namespace Subscriber1
{
    public class MyOtherEventHandler : IHandleMessages<MyOtherEvent>
    {
        public Task Handle(MyOtherEvent message, IMessageHandlerContext context)
        {
            Console.WriteLine("Got MyOtherEvent");
            return Task.CompletedTask;
        }
    }
}