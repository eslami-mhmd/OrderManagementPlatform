using CustomerEntity = Customer.Domain.Entities.Customer;
using MediatR;

namespace Customer.Application.Customers.CreateCustomer;

public sealed class CreateCustomerCommandHandler
    : IRequestHandler<CreateCustomerCommand, Guid>
{
    public async Task<Guid> Handle(
        CreateCustomerCommand request,
        CancellationToken cancellationToken)
    {
        var customer = CustomerEntity.Create(
            request.Name,
            request.Email);


        // Database will be added in Commit 5


        return customer.Id;
    }
}