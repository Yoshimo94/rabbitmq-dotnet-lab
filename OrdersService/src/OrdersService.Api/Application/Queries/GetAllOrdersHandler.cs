using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersService.Api.Domain;
using OrdersService.Api.Infrastructure.Data;

namespace OrdersService.Api.Application.Queries
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrders, List<Order>>
    {
        private readonly OrdersDbContext _db;

        public GetAllOrdersHandler(OrdersDbContext db)
        {
            _db = db;
        }

        public async Task<List<Order>> Handle(GetAllOrders request, CancellationToken cancellationToken)
        {
            return await _db.Orders.ToListAsync(cancellationToken);
        }
    }
}
