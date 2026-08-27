using MediatR;
using Order.Application.Common.Interfaces;

namespace Order.Application.Orders.GetOrder;

public sealed class GetOrderQueryHandler
    : IRequestHandler<GetOrderQuery, OrderResponse?>
{
    private readonly IOrderRepository _repository;


    public GetOrderQueryHandler(
        IOrderRepository repository)
    {
        _repository = repository;
    }


    public async Task<OrderResponse?> Handle(
        GetOrderQuery request,
        CancellationToken cancellationToken)
    {
        var order =
            await _repository.GetByIdAsync(
                request.Id,
                cancellationToken);


        if (order is null)
            return null;


        return new OrderResponse(
            order.Id,
            order.CustomerId,
            order.CreatedAt);
    }
}