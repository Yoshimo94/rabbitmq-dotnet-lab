namespace OrdersService.Api.Infrastructure.Messaging
{
    public interface IEventPublisher
    {
        Task PublishAsync(string type, string payload);
    }
}
