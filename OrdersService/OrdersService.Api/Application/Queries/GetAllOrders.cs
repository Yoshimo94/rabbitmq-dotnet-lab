using MediatR;
using OrdersService.Api.Models;

namespace OrdersService.Api.Application.Queries
{
    public record GetAllOrders() : IRequest<List<Order>>;
}
