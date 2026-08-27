using Order.API.Endpoints;
using Order.Application;
using Order.Infrastructure;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddApplication();

builder.Services.AddInfrastructure(
    builder.Configuration);



var app = builder.Build();


app.MapOrderEndpoints();


app.Run();