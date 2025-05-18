using ChessHandler.Application.Members.Commands.AddGame;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChessHandler.Api;

public static class Extensions
{
    public static WebApplication AddEndpoints(this WebApplication app)
    {
        const string lichessPrefix = "lichess";
        const string gamesPrefix = "games";
        
        app.MapPut($"/{lichessPrefix}/update", async ([FromBody] UpdateLichessGames command, ISender sender) =>
        {
            await sender.Send(command);
            return Results.NoContent();
        });

        return app;
    }
}