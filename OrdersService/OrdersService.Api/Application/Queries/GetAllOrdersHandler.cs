using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersService.Api.Data;
using OrdersService.Api.Models;

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
