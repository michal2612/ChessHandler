using ChessHandler.Infrastructure;
using ChessHandler.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddOpenApi()
    .AddInstrastructure(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();

app.Run();
