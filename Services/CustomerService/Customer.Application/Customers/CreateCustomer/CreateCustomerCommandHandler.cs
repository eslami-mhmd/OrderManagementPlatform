using Contracts;
using Customer.Application.Common.Interfaces;
using CustomerEntity = Customer.Domain.Entities.Customer;
using MediatR;

namespace Customer.Application.Customers.CreateCustomer;

public sealed class CreateCustomerCommandHandler
    : IRequestHandler<CreateCustomerCommand, Guid>
{
    private readonly ICustomerRepository _repository;
    private readonly IMessagePublisher _publisher;


    public CreateCustomerCommandHandler(
        ICustomerRepository repository,
        IMessagePublisher publisher)
    {
        _repository = repository;
        _publisher = publisher;
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


        await _publisher.PublishAsync(
            new CustomerCreatedMessage(
                customer.Id,
                customer.Name,
                customer.Email),
            cancellationToken);


        return customer.Id;
    }
}