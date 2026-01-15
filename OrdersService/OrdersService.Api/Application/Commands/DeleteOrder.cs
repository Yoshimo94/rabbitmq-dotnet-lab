using MediatR;

namespace OrdersService.Api.Application.Commands
{
    public record DeleteOrder(Guid Id) : IRequest<bool>;
}
