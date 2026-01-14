using MediatR;
using OrdersService.Api.Models;

namespace OrdersService.Api.Application.Commands
{
    public record DeleteOrder(Guid Id) : IRequest<bool>;
}
