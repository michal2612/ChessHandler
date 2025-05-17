using ChessHandler.Core.Entities;
using ChessHandler.Core.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

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
            return JsonConvert.DeserializeObject<Game>(cachedMember)!;
        
        var game = await decorated.GetAsync(gameId);

        if (game == null)
            return game;
        
        await distributedCache.SetStringAsync(key, JsonConvert.SerializeObject(game));
        return game;
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