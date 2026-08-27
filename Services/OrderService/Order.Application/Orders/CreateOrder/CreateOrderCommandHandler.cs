using MediatR;
using OrderEntity = Order.Domain.Entities.Order;

namespace Order.Application.Orders.CreateOrder;

public sealed class CreateOrderCommandHandler
    : IRequestHandler<CreateOrderCommand, Guid>
{
    public async Task<Guid> Handle(
        CreateOrderCommand request,
        CancellationToken cancellationToken)
    {
        var order = OrderEntity.Create(
            request.CustomerId);


        // Database will be added later


        return order.Id;
    }
}