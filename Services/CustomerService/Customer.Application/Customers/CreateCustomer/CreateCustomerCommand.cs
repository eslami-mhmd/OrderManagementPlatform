using MediatR;

namespace Customer.Application.Customers.CreateCustomer;

public sealed record CreateCustomerCommand(
    string Name,
    string Email)
    : IRequest<Guid>;