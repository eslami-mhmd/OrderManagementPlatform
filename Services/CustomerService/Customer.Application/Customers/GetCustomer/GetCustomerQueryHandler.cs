using MediatR;

namespace Customer.Application.Customers.GetCustomer;

public sealed class GetCustomerQueryHandler
    : IRequestHandler<GetCustomerQuery, CustomerResponse?>
{
    public async Task<CustomerResponse?> Handle(
        GetCustomerQuery request,
        CancellationToken cancellationToken)
    {
        // Database will be added in Commit 5

        return null;
    }
}