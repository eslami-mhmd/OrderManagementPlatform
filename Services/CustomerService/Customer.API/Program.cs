using Customer.API.Endpoints;
using Customer.Application;
using Customer.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddApplication();

builder.Services.AddInfrastructure(
    builder.Configuration);


var app = builder.Build();


app.MapCustomerEndpoints();


app.Run();