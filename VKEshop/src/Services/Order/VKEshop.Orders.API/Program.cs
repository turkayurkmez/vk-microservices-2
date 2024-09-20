using MassTransit;
using System.ComponentModel.DataAnnotations;
using VKEshop.MessageBus;
using VKEshop.Orders.API.Consumers;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<ProductPriceDiscountedConsumer>();
    config.AddConsumer<PaymentSuccesedEventConsumer>();
    config.AddConsumer<PaymentFailedEventConsumer>();
    config.AddConsumer<StockNotAvailableEventConsumer>();


    config.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host("rabbit-mq", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        configurator.ReceiveEndpoint(nameof(ProductPriceDiscountedEvent), c => c.ConfigureConsumer<ProductPriceDiscountedConsumer>(context));
        configurator.ConfigureEndpoints(context);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.MapPost("orderCreate", async (IPublishEndpoint publishEndPoint,  OrderCreateRequest request) =>
{
    //db'de eklendiğini var sayın!
    var @event = new OrderCreatedEvent();
    var orderId = new Random().Next(1000, 5000);
    var orderItems = request.OrderItems.Select(oi => new OrderItems(oi.ProductId, oi.Quantity, oi.Price));
    var eventCommand = new OrderCreatedCommand(orderId, request.CustomerId, request.CredidCardInfo, orderItems);
    @event.OrderCreatedCommand = eventCommand;

   await publishEndPoint.Publish(@event);
    app.Logger.LogInformation("Sipariş olayı gönderildi");
});

app.Run();


public record OrderCreateRequest
{
    [Required]
    public int CustomerId { get; set; }
    [Required] 
    public string CredidCardInfo { get; set; }

    public List<OrderItem> OrderItems { get; set; }
}

public record OrderItem(int ProductId, int Quantity, decimal? Price);