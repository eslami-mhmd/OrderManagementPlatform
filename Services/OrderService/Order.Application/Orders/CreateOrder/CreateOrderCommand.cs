using MediatR;

namespace Order.Application.Orders.CreateOrder;

public sealed record CreateOrderCommand(
    Guid CustomerId)
    : IRequest<Guid>;