using System.Text.Json;
using ChessHandler.Core.Entities;
using ChessHandler.Core.Repositories;
using Microsoft.Extensions.Caching.Distributed;

namespace ChessHandler.Infrastructure.DAL.Repositories;

internal sealed class CachedGamesRepository(IGamesRepository decorated,
    IDistributedCache distributedCache)
    : IGamesRepository
{
    public async Task<Game> GetAsync(int gameId)
    {
        var key = $"game-{gameId}";
        string? cachedMember = await distributedCache.GetStringAsync(key);

        if (!string.IsNullOrEmpty(cachedMember))
            return JsonSerializer.Deserialize<Game>(cachedMember)!;
        
        var game = await decorated.GetAsync(gameId);

        if (game == null)
            return game;
        
        await distributedCache.SetStringAsync(key, JsonSerializer.Serialize(game));
        return game;
    }

    public async Task<IEnumerable<Game>> GetAllAsync(DateTime since, uint max = 100)
    {
        var key = $"games-{since:yyyyMMdd}";
        string? cachedMember = await distributedCache.GetStringAsync(key);

        if (!string.IsNullOrEmpty(cachedMember))
            return JsonSerializer.Deserialize<IEnumerable<Game>>(cachedMember)!;
        
        var games = await decorated.GetAllAsync(since, max);

        var allGames = games as Game[] ?? games.ToArray();
        if (allGames.Length == 0) return [];
        
        await distributedCache.SetStringAsync(key, JsonSerializer.Serialize(games));

        return allGames;
    }

    public Task<IEnumerable<Game>> GetWithPaginationAsync(int page, int pageSize)
    {
        return decorated.GetWithPaginationAsync(page, pageSize);
    }

    public Task AddAsync(Game game) => decorated.AddAsync(game);
}