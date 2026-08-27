using MediatR;
using Order.Application.Common.Interfaces;
using OrderEntity = Order.Domain.Entities.Order;

namespace Order.Application.Orders.CreateOrder;

public sealed class CreateOrderCommandHandler
    : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly IOrderRepository _repository;


    public CreateOrderCommandHandler(
        IOrderRepository repository)
    {
        _repository = repository;
    }


    public async Task<Guid> Handle(
        CreateOrderCommand request,
        CancellationToken cancellationToken)
    {
        var order = OrderEntity.Create(
            request.CustomerId);


        await _repository.AddAsync(
            order,
            cancellationToken);


        return order.Id;
    }
}