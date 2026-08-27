using Customer.Application.Common.Interfaces;
using CustomerEntity = Customer.Domain.Entities.Customer;
using Microsoft.EntityFrameworkCore;

namespace Customer.Infrastructure.Persistence;

public sealed class CustomerRepository
    : ICustomerRepository
{
    private readonly CustomerDbContext _context;


    public CustomerRepository(
        CustomerDbContext context)
    {
        _context = context;
    }


    public async Task AddAsync(
        CustomerEntity customer,
        CancellationToken cancellationToken = default)
    {
        await _context.Customers.AddAsync(
            customer,
            cancellationToken);

        await _context.SaveChangesAsync(
            cancellationToken);
    }


    public async Task<CustomerEntity?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _context.Customers
            .FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken);
    }
}