using MediatR;
using OrdersService.Api.Domain;

namespace OrdersService.Api.Application.Queries
{
    public record GetAllOrders() : IRequest<List<Order>>;
}
