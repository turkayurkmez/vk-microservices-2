using MassTransit;
using VKEshop.Basket.API.Consumers;
using VKEshop.Basket.API.Repositories;
using VKEshop.Basket.API.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IBasketRepository, BasketRepository>();
// Add services to the container.
builder.Services.AddGrpc();

builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<ProductPriceDiscountedConsumer>();
    config.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        configurator.ConfigureEndpoints(context);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<BasketService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
