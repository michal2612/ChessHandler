using ChessHandler.Api;
using ChessHandler.Application;
using ChessHandler.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddOpenApi()
    .AddApp()
    .AddInfrastructure(builder.Configuration);

builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(5089);
});

var app = builder.Build();

app.AddEndpoints();

app.UseHttpsRedirection();

app.Run();
