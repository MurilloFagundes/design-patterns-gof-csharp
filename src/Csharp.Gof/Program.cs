using Csharp.Gof.Application.DependencyInjection;
using Csharp.Gof.Application.Features.Notifications.Commands;
using Csharp.Gof.Controllers;
using Scalar.AspNetCore;
using Wolverine;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Host.UseWolverine(opts =>
{
    opts.Durability.Mode = DurabilityMode.MediatorOnly;
    opts.Policies.AutoApplyTransactions();
    opts.Discovery.IncludeAssembly(typeof(SenderNotificationCommand).Assembly);
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger().UseSwaggerUI();
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        // Fluent API
        options
            .WithTitle("Custom API")
            .WithSidebar(false)
            .WithCdnUrl("https://cdn.jsdelivr.net/npm/@scalar/api-reference");

        // Object initializer
        options.ShowSidebar = false;
    });
}

app.UseHttpsRedirection();

app.MapNotificationsEndpoints();

app.Run();
