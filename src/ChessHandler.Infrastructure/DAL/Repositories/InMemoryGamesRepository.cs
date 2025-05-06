using ChessHandler.Core.Entities;
using ChessHandler.Core.Repositories;

namespace ChessHandler.Infrastructure.DAL.Repositories;

internal sealed class InMemoryGamesRepository : IGamesRepository
{
    private readonly List<Game> _games = new();
    
    public Task<Game> GetAsync(int gameId)
    {
        return Task.FromResult(_games.SingleOrDefault(g => g.Id == gameId));
    }

    public Task<IEnumerable<Game>> GetAllAsync(DateTime since, uint max = 100)
    {
        return Task.FromResult<IEnumerable<Game>>(_games);
    }

    public Task AddAsync(Game game)
    {
        _games.Add(game);
        return Task.CompletedTask;
    }
}