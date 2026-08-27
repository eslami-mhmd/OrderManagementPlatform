using Contracts;
using MassTransit;
using Order.Application.Common.Interfaces;
using Order.Domain.Entities;

namespace Order.Infrastructure.Messaging;

public sealed class CustomerCreatedConsumer
    : IConsumer<CustomerCreatedMessage>
{
    private readonly ICustomerRepository _repository;


    public CustomerCreatedConsumer(
        ICustomerRepository repository)
    {
        _repository = repository;
    }


    public async Task Consume(
        ConsumeContext<CustomerCreatedMessage> context)
    {
        var message = context.Message;


        var customer = Customer.Create(
            message.CustomerId,
            message.Name,
            message.Email);


        await _repository.AddAsync(
            customer);
    }
}