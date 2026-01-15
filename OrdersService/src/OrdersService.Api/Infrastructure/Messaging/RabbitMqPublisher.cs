namespace OrdersService.Api.Infrastructure.Messaging
{
    public class RabbitMqPublisher : IEventPublisher
    {
        public Task PublishAsync(string type, string payload) 
        {
            Console.WriteLine($"Publishing {type}: {payload}");
            return Task.CompletedTask;
        }
    }
}
