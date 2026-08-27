using OrderEntity = Order.Domain.Entities.Order;

namespace Order.Application.Common.Interfaces;

public interface IOrderRepository
{
    Task AddAsync(
        OrderEntity order,
        CancellationToken cancellationToken = default);


    Task<OrderEntity?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);
}