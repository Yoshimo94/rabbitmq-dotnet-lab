using Contracts;
using MassTransit;

namespace Consumer
{
    public class OrderCreatedConsumer : IConsumer<OrderCreated>
    {
        public Task Consume(ConsumeContext<OrderCreated> context)
        {
            Console.WriteLine($"Received: {context.Message.OrderId}");
            return Task.CompletedTask;
        }
    }
}
