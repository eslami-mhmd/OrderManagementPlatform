using Microsoft.EntityFrameworkCore;
using Order.Application.Common.Interfaces;
using OrderEntity = Order.Domain.Entities.Order;

namespace Order.Infrastructure.Persistence;

public sealed class OrderRepository
    : IOrderRepository
{
    private readonly OrderDbContext _context;


    public OrderRepository(
        OrderDbContext context)
    {
        _context = context;
    }


    public async Task AddAsync(
        OrderEntity order,
        CancellationToken cancellationToken = default)
    {
        await _context.Orders.AddAsync(
            order,
            cancellationToken);


        await _context.SaveChangesAsync(
            cancellationToken);
    }


    public async Task<OrderEntity?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _context.Orders
            .FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken);
    }
}