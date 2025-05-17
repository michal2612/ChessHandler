using ChessHandler.Core.Entities;
using ChessHandler.Core.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace ChessHandler.Infrastructure.DAL.Repositories;

internal sealed class CachedGamesRepository(IGamesRepository decorated,
    IMemoryCache cache)
    : IGamesRepository
{
    public Task<Game> GetAsync(int gameId)
    {
        var key = $"game-{gameId}";

        return cache.GetOrCreateAsync(key, entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromHours(2));
            return decorated.GetAsync(gameId);
        });
    }

    public Task<IEnumerable<Game>> GetAllAsync(DateTime since, uint max = 100)
    {
        return decorated.GetAllAsync(since, max);
    }

    public Task<IEnumerable<Game>> GetWithPaginationAsync(int page, int pageSize)
    {
        return decorated.GetWithPaginationAsync(page, pageSize);
    }

    public Task AddAsync(Game game)
    {
        return decorated.AddAsync(game);
    }
}