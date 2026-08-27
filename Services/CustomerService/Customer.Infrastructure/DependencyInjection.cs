using Customer.Application.Common.Interfaces;
using Customer.Infrastructure.Messaging;
using Customer.Infrastructure.Persistence;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Customer.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<CustomerDbContext>(options =>
        {
            options.UseNpgsql(
                configuration.GetConnectionString(
                    "CustomerDb"));
        });


        services.AddScoped<
            ICustomerRepository,
            CustomerRepository>();

        services.AddScoped<
            IMessagePublisher,
            RabbitMqMessagePublisher>();


        services.AddMassTransit(x =>
        {
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
            });
        });


        return services;
    }
}