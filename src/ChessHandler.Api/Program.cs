using ChessHandler.Api;
using ChessHandler.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddOpenApi()
    .AddInstrastructure(builder.Configuration);

var app = builder.Build();

app.AddEndpoints();

app.UseHttpsRedirection();

app.Run();
