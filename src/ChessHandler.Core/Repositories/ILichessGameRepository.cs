using ChessHandler.Core.Entities;

namespace ChessHandler.Core.Repositories;

public interface ILichessGameRepository
{
    Task<Game> GetAsync(string gameId);
    Task<IEnumerable<Game>> GetAllAsync(DateTime since, uint max = 100);
    
    Task AddAsync(Game game);
    Task UpdateAsync(Game game);
    Task DeleteAsync(Game game);
}