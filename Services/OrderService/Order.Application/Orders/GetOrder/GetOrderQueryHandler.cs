using MediatR;

namespace Order.Application.Orders.GetOrder;

public sealed class GetOrderQueryHandler
    : IRequestHandler<GetOrderQuery, OrderResponse?>
{
    public async Task<OrderResponse?> Handle(
        GetOrderQuery request,
        CancellationToken cancellationToken)
    {
        // Database will be added later

        return null;
    }
}