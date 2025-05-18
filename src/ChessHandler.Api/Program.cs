using ChessHandler.Api;
using ChessHandler.Application;
using ChessHandler.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddOpenApi()
    .AddApp()
    .AddInstrastructure(builder.Configuration);

builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});

var app = builder.Build();

app.AddEndpoints();

app.UseHttpsRedirection();

app.Run();
