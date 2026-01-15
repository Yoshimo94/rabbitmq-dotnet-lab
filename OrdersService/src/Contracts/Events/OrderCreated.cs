namespace Contracts.Events
{
    public record OrderCreated(Guid OrderId, DateTime CreatedAtUtc);
}
