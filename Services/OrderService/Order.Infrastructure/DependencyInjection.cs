using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.Application.Common.Interfaces;
using Order.Infrastructure.Messaging;
using Order.Infrastructure.Persistence;

namespace Order.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<OrderDbContext>(options =>
        {
            options.UseNpgsql(
                configuration.GetConnectionString("OrderDb"));
        });


        services.AddScoped<
            IOrderRepository,
            OrderRepository>();


        services.AddScoped<
            ICustomerRepository,
            CustomerRepository>();


        services.AddMassTransit(x =>
        {
            x.AddConsumer<CustomerCreatedConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                var rabbit =
                    configuration
                        .GetSection("RabbitMq")
                        .Get<RabbitMqOptions>();


                cfg.Host(
                    rabbit!.Host,
                    "/",
                    h =>
                    {
                        h.Username(rabbit.Username);
                        h.Password(rabbit.Password);
                    });


                cfg.ReceiveEndpoint(
                    "customer-created-queue",
                    e =>
                    {
                        e.ConfigureConsumer<CustomerCreatedConsumer>(
                            context);
                    });
            });
        });


        return services;
    }
}