using CustomerEntity = Customer.Domain.Entities.Customer;

namespace Customer.Application.Common.Interfaces;

public interface ICustomerRepository
{
    Task AddAsync(
        CustomerEntity customer,
        CancellationToken cancellationToken = default);


    Task<CustomerEntity?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);
}