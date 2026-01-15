namespace OrdersService.Api.Domain.Events
{
    public record OrderCreated(Guid OrderId, DateTime CreatedAtUtc);
}
