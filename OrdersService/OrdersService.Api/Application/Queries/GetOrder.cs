using MediatR;
using OrdersService.Api.Models;

namespace OrdersService.Api.Application.Queries
{
    public record GetOrder(Guid Id) : IRequest<Order>;
}
