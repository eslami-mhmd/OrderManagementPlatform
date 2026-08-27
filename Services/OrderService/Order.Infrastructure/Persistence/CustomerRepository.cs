using Order.Application.Common.Interfaces;
using Order.Domain.Entities;

namespace Order.Infrastructure.Persistence;

public sealed class CustomerRepository
    : ICustomerRepository
{
    private readonly OrderDbContext _context;


    public CustomerRepository(
        OrderDbContext context)
    {
        _context = context;
    }


    public async Task AddAsync(
        Customer customer,
        CancellationToken cancellationToken = default)
    {
        await _context.Customers.AddAsync(
            customer,
            cancellationToken);


        await _context.SaveChangesAsync(
            cancellationToken);
    }
}