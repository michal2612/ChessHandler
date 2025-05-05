using ChessHandler.Application.Lichess;

namespace ChessHandler.Api;

public static class Extensions
{
    public static WebApplication AddEndpoints(this WebApplication app)
    {
        const string lichessPrefix = "lichess";

        // Lichess
        app.MapPut($"/{lichessPrefix}/{{id}}", async (string id, LichessService service) =>
            await service.GetGamesForUser(id).ConfigureAwait(false));
        
        // Chess.com
        
        // Db
        
        return app;
    }
}