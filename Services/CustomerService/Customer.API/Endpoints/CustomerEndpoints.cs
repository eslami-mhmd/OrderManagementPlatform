using Customer.Application.Customers.CreateCustomer;
using Customer.Application.Customers.GetCustomer;
using MediatR;

namespace Customer.API.Endpoints;

public static class CustomerEndpoints
{
    public static void MapCustomerEndpoints(
        this WebApplication app)
    {
        app.MapPost(
            "/customers",
            async (
                CreateCustomerRequest request,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var id = await sender.Send(
                    new CreateCustomerCommand(
                        request.Name,
                        request.Email),
                    cancellationToken);


                return Results.Created(
                    $"/customers/{id}",
                    new
                    {
                        Id = id
                    });
            });



        app.MapGet(
            "/customers/{id:guid}",
            async (
                Guid id,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var customer = await sender.Send(
                    new GetCustomerQuery(id),
                    cancellationToken);


                if (customer is null)
                {
                    return Results.NotFound();
                }


                return Results.Ok(customer);
            });
    }
}


public sealed record CreateCustomerRequest(
    string Name,
    string Email);