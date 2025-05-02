using ChessHandler.Core.Entities;
using ChessHandler.Core.Repositories;

namespace ChessHandler.Infrastructure.DAL.Repositories;

public class PostgresGamesRepository : ILichessGameRepository
{
    public Task<Game> GetAsync(string gameId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Game>> GetAllAsync(DateTime since, uint max = 100)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Game game)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Game game)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Game game)
    {
        throw new NotImplementedException();
    }
}