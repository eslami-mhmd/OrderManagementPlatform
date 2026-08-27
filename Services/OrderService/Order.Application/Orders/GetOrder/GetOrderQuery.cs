using MediatR;

namespace Order.Application.Orders.GetOrder;

public sealed record GetOrderQuery(
    Guid Id)
    : IRequest<OrderResponse?>;


public sealed record OrderResponse(
    Guid Id,
    Guid CustomerId,
    DateTime CreatedAt);