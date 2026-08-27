using Customer.Application.Common.Interfaces;
using Customer.Infrastructure.Persistence;
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


        return services;
    }
}