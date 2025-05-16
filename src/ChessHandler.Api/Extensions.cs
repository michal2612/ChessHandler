using ChessHandler.Application.Lichess;
using ChessHandler.Core.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            var games = await service.GetGamesForUser(id, 50_000).ConfigureAwait(false);

            foreach (var game in games) await repository.AddAsync(game.FromDto());
        });
        
        // Chess.com
        
        // Db
        app.MapGet($@"/{gamesPrefix}/{{id}}", async (int id, IGamesRepository repository)
            => await repository.GetAsync(id));
        
        app.MapGet($"/{gamesPrefix}", async (IGamesRepository repository) =>
        {
            var games = await repository.GetAllAsync(DateTime.Now);
            return games;
        });

        app.MapGet($"{gamesPrefix}/pagination",
        async (int page, int pageSize, IGamesRepository repository)
            => await repository.GetWithPaginationAsync(page, pageSize));

        return app;
    }
}