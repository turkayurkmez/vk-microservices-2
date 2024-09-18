using VKEshop.Catalog.Application.Features.Products.GetAllProducts;
using Microsoft.EntityFrameworkCore;
using VKEshop.Catalog.Persistence.Data;
using VKEshop.Catalog.Application.Contracts.Repository;
using VKEshop.Catalog.Persistence.Repositories;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblyContaining<GetAllProductsQuery>());

var connectionString = builder.Configuration.GetConnectionString("db");
builder.Services.AddDbContext<VKEshopCatalogDb>(option => option.UseSqlServer(connectionString));
builder.Services.AddScoped<IProductRepository, EFProductRepository>();

builder.Services.AddMassTransit(config =>
{
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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
