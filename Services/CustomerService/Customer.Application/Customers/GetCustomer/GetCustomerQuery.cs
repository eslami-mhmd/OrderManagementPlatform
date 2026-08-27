using MediatR;

namespace Customer.Application.Customers.GetCustomer;

public sealed record GetCustomerQuery(
    Guid Id)
    : IRequest<CustomerResponse?>;


public sealed record CustomerResponse(
    Guid Id,
    string Name,
    string Email);