using MediatR;
using OrdersService.Api.Domain;

namespace OrdersService.Api.Application.Queries
{
    public record GetOrder(Guid Id) : IRequest<Order>;
}
