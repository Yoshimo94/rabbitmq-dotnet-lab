using Consumer;
using Contracts;
using MassTransit;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<OrderCreatedConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("localhost", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.Message<OrderCreated>(m => m.SetEntityName("order-created"));

                cfg.ReceiveEndpoint("order-created", e =>
                {
                    e.ConfigureConsumer<OrderCreatedConsumer>(context);
                });
            });
        });
    });

var app = builder.Build();
await app.StartAsync();

Console.WriteLine("Consumer running...");
await app.WaitForShutdownAsync();
