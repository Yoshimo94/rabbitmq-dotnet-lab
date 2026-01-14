using Contracts;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("localhost", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                // Taka sama nazwa exchange jak w Consumer!
                cfg.Message<OrderCreated>(m => m.SetEntityName("order-created"));
            });
        });
    });

var app = builder.Build();
var bus = app.Services.GetRequiredService<IBus>();

await app.StartAsync();
Console.WriteLine("Publishing...");

await bus.Publish(new OrderCreated(Guid.NewGuid()));
Console.WriteLine("Message published");

Console.ReadLine();

await app.StopAsync();