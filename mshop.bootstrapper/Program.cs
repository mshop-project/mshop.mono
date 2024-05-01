using mshop.products.api;
using mshop.orders.api;
using mshop.discounts.api;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddOrdersExtensions(builder.Configuration)
    .AddDiscountExtensions(builder.Configuration)
    .AddProductsExtensions(builder.Configuration);


builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.SetKebabCaseEndpointNameFormatter();
    
    busConfigurator.UsingInMemory((context, config) => config.ConfigureEndpoints(context));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
