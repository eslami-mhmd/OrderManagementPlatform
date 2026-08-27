using Customer.Application.Common.Interfaces;
using CustomerEntity = Customer.Domain.Entities.Customer;
using MediatR;

namespace Customer.Application.Customers.CreateCustomer;

public sealed class CreateCustomerCommandHandler
    : IRequestHandler<CreateCustomerCommand, Guid>
{
    private readonly ICustomerRepository _repository;


    public CreateCustomerCommandHandler(
        ICustomerRepository repository)
    {
        _repository = repository;
    }


    public async Task<Guid> Handle(
        CreateCustomerCommand request,
        CancellationToken cancellationToken)
    {
        var customer = CustomerEntity.Create(
            request.Name,
            request.Email);


        await _repository.AddAsync(
            customer,
            cancellationToken);


        return customer.Id;
    }
}