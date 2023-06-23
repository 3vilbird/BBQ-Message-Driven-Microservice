using MassTransit;
using orderservice;
using orderservice.MessageConsumer;
using orderservice.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IOrderService, OrderService>();


// mass trient configuration // make sure that u use the proper versions
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<MessageConsumer>(); // adding the consumer
    x.AddBus(context => Bus.Factory.CreateUsingRabbitMq(config =>
    {
        config.Host(new Uri("rabbitmq://rabbitmqservice"), h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        config.ReceiveEndpoint("PaymentStatus", c =>
        {
            c.ConfigureConsumer<MessageConsumer>(context);

        });
    }));
});

builder.Services.AddMassTransitHostedService();

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
