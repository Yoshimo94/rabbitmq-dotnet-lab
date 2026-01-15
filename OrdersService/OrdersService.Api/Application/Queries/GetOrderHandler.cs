using MediatR;
using OrdersService.Api.Application.Commands;
using OrdersService.Api.Domain;
using OrdersService.Api.Infrastructure.Data;

namespace OrdersService.Api.Application.Queries
{
    public class GetOrderHandler : IRequestHandler<GetOrder, Order>
    {
        private readonly OrdersDbContext _db;

        public GetOrderHandler(OrdersDbContext db)
        {
            _db = db;
        }

        public async Task<Order> Handle(GetOrder request, CancellationToken cancellationToken)
        {
            return await _db.Orders.FindAsync(new object[] {request.Id}, cancellationToken);
        }
    }
}
