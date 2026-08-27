using MediatR;
using Order.Application.Orders.CreateOrder;
using Order.Application.Orders.GetOrder;

namespace Order.API.Endpoints;

public static class OrderEndpoints
{
    public static void MapOrderEndpoints(
        this WebApplication app)
    {
        app.MapPost(
            "/orders",
            async (
                CreateOrderRequest request,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var id = await sender.Send(
                    new CreateOrderCommand(
                        request.CustomerId),
                    cancellationToken);


                return Results.Created(
                    $"/orders/{id}",
                    new
                    {
                        Id = id
                    });
            });



        app.MapGet(
            "/orders/{id:guid}",
            async (
                Guid id,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var order = await sender.Send(
                    new GetOrderQuery(id),
                    cancellationToken);


                if (order is null)
                {
                    return Results.NotFound();
                }


                return Results.Ok(order);
            });
    }
}


public sealed record CreateOrderRequest(
    Guid CustomerId);