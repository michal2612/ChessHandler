using ChessHandler.Core.Entities;
using ChessHandler.Core.Repositories;

namespace ChessHandler.Infrastructure.DAL.Repositories;

public class PostgresPlayersRepository : ILichessPlayerRepository
{
    public Task<GamePlayer> GetAsync(int playerId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GamePlayer>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(GamePlayer player)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(GamePlayer player)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(GamePlayer player)
    {
        throw new NotImplementedException();
    }
}