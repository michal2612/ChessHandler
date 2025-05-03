using ChessHandler.Core.Entities;

namespace ChessHandler.Core.Repositories;

public interface ILichessGameRepository
{
    Task<Game> GetAsync(int gameId);
    Task<IEnumerable<Game>> GetAllAsync(DateTime since, uint max = 100);
    
    Task AddAsync(Game game);
}