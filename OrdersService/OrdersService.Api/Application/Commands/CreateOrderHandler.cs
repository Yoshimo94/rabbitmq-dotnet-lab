using MediatR;
using OrdersService.Api.Data;
using OrdersService.Api.Models;

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
                Price = request.Price
            };

            _db.Orders.Add(order);
            await _db.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
