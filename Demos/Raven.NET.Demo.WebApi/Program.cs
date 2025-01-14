using Raven.NET.Core.Configuration;
using Raven.NET.Demo.WebApi.Repositories;
using Raven.NET.Demo.WebApi.Repositories.Interfaces;
using Raven.NET.Demo.WebApi.Services;
using Raven.NET.Demo.WebApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => { c.EnableAnnotations(); });
builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
builder.Services.AddSingleton<IOrderRepository, OrderRepository>();
builder.Services.AddSingleton<ICustomerUpdateService, CustomerUpdateService>();
builder.Services.AddSingleton<IOrderUpdateService, OrderUpdateService>();
builder.Services.ConfigureRaven(builder.Configuration);

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


//PS: This api is not an example of properly done SOLID Web Api, its simple showcase to see how Raven.NET components can be implemented