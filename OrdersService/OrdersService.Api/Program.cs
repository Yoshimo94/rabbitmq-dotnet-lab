using MediatR;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OrdersService.Api.Application.Commands;
using OrdersService.Api.Application.Queries;
using OrdersService.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "OrderService API",
        Version = "v1",
        Description = "API for managing orders."
    });
});

builder.Services.AddDbContext<OrdersDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("OrdersDb")));

builder.Services.AddMediatR(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Swagger UI
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "OrderService API V1");
});

app.UseHttpsRedirection();

app.MapPost("/orders", async (CreateOrder command, IMediator mediator) =>
{
    var id = await mediator.Send(command);
    return Results.Created($"/orders/{id}", new { Id = id });
});

app.MapGet("/orders", async (IMediator mediator) =>
{
    var orders = await mediator.Send(new GetAllOrders());
    return Results.Ok(orders);
});

app.MapGet("/orders/{id}", async (Guid id, IMediator mediator) =>
{
    var order = await mediator.Send(new GetOrder(id));
    return order is null ? Results.NotFound() : Results.Ok(order);
});

app.MapDelete("/orders/{id}", async (Guid id, IMediator mediator) =>
{
    var deleted = await mediator.Send(new DeleteOrder(id));
    return deleted ? Results.NoContent() : Results.NotFound();
});

app.MapGet("/", () => "Orders Service");

app.Run();

