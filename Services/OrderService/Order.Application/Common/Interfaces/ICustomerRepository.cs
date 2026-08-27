using Order.Domain.Entities;

namespace Order.Application.Common.Interfaces;

public interface ICustomerRepository
{
    Task AddAsync(
        Customer customer,
        CancellationToken cancellationToken = default);
}