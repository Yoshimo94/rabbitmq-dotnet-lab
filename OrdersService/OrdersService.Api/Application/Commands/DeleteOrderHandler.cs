using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using OrdersService.Api.Data;
using OrdersService.Api.Models;

namespace OrdersService.Api.Application.Commands
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrder, bool>
    {
        private readonly OrdersDbContext _db;

        public DeleteOrderHandler(OrdersDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(DeleteOrder request, CancellationToken cancellationToken)
        {
            var order = await _db.Orders.FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

            if (order is null)
            {
                return false;
            }

            _db.Orders.Remove(order);
            await _db.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
