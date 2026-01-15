using MediatR;
using OrdersService.Api.Infrastructure.Data;
using OrdersService.Api.Domain;
using System.Text.Json;
using Contracts.Events;

namespace OrdersService.Api.Application.Commands
{
    public class CreateOrderHandler : IRequestHandler<CreateOrder, Guid>
    {
        private readonly OrdersDbContext _db;

        public CreateOrderHandler(OrdersDbContext db)
        {
            _db = db;
        }

        public async Task<Guid> Handle(CreateOrder request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                ProductName = request.ProductName,
                Price = request.Price,
                CreatedAtUtc = DateTime.UtcNow,
            };

            var @event = new OrderCreated(order.Id, order.CreatedAtUtc);

            var outboxMessage = new OutboxMessage()
            {
                Id = Guid.NewGuid(),
                Type = nameof(OrderCreated),
                Content = JsonSerializer.Serialize(@event),
                OccurredOnUtc = DateTime.UtcNow,
            };

            _db.Orders.Add(order);
            _db.OutboxMessages.Add(outboxMessage);

            await _db.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
