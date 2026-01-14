using MediatR;

namespace OrdersService.Api.Application.Commands
{
    public record CreateOrder(string ProductName, decimal Price) : IRequest<Guid>;
}
