using ChessHandler.Application.Members.Commands.AddGame;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Serilog.Sinks.File;

namespace ChessHandler.Api;

public static class Extensions
{
    public static ConfigureHostBuilder AddSerilog(this ConfigureHostBuilder hostBuilder)
    {
        hostBuilder.UseSerilog((context, configuration) =>
        {
            configuration.ReadFrom.Configuration(context.Configuration);
        });
        return hostBuilder;
    }
    
    public static WebApplication AddEndpoints(this WebApplication app)
    {
        const string lichessPrefix = "lichess";
        const string gamesPrefix = "games";
        
        app.MapPut($"/{lichessPrefix}/update", async ([FromBody] UpdateLichessGamesCommand command, ISender sender) =>
        {
            await sender.Send(command);
            return Results.NoContent();
        });

        return app;
    }
}