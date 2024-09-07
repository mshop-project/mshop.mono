using mshop.products.api;
using mshop.orders.api;
using mshop.discounts.api;
using MassTransit;
using mshop.orders.infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddOrdersExtensions(builder.Configuration)
    .AddDiscountExtensions(builder.Configuration)
    .AddProductsExtensions(builder.Configuration);

/*builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.SetKebabCaseEndpointNameFormatter();

    busConfigurator.AddOrdersBusConfig();
    busConfigurator.AddProductsBusConfig();

    busConfigurator.UsingInMemory((context, config) =>
    {
        config.ConfigureEndpoints(context);
    });
});*/

builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.SetKebabCaseEndpointNameFormatter();

    busConfigurator.AddOrdersBusConfig();
    busConfigurator.AddProductsBusConfig();


    busConfigurator.UsingRabbitMq((context, config) =>
    {
        config.Host("rabbitmq", "/", hostConfigurator =>
        {
            hostConfigurator.Username("guest");
            hostConfigurator.Password("guest");
        });

        config.ConfigureEndpoints(context);
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
    options.AddPolicy(name: "CORS",
            policy =>
            {
                policy.WithOrigins("*")
                 .AllowAnyHeader()
                 .AllowAnyMethod()
                 .AllowAnyOrigin();
            }));

var app = builder.Build();
app.UseCors("CORS");

// Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
