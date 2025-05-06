using ChessHandler.Application.Lichess;
using ChessHandler.Core.Repositories;

namespace ChessHandler.Api;

public static class Extensions
{
    public static WebApplication AddEndpoints(this WebApplication app)
    {
        const string lichessPrefix = "lichess";
        const string gamesPrefix = "games";

        // Lichess
        app.MapPut($"/{lichessPrefix}/{{id}}", 
            async (string id, LichessService service, IGamesRepository repository) =>
        {
            var games = await service.GetGamesForUser(id).ConfigureAwait(false);

            foreach (var game in games) await repository.AddAsync(game.FromDto());
        });
        
        // Chess.com
        
        // Db
        app.MapGet($"/{gamesPrefix}", async (IGamesRepository repository) =>
        {
            var games = await repository.GetAllAsync(DateTime.Now);
            return games;
        });

        return app;
    }
}