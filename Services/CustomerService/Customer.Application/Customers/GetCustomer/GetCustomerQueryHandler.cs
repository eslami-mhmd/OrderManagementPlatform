using Customer.Application.Common.Interfaces;
using MediatR;

namespace Customer.Application.Customers.GetCustomer;

public sealed class GetCustomerQueryHandler
    : IRequestHandler<GetCustomerQuery, CustomerResponse?>
{
    private readonly ICustomerRepository _repository;


    public GetCustomerQueryHandler(
        ICustomerRepository repository)
    {
        _repository = repository;
    }


    public async Task<CustomerResponse?> Handle(
        GetCustomerQuery request,
        CancellationToken cancellationToken)
    {
        var customer =
            await _repository.GetByIdAsync(
                request.Id,
                cancellationToken);


        if (customer is null)
            return null;


        return new CustomerResponse(
            customer.Id,
            customer.Name,
            customer.Email);
    }
}