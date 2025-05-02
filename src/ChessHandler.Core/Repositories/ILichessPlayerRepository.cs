using ChessHandler.Core.Entities;

namespace ChessHandler.Core.Repositories;

public interface ILichessPlayerRepository
{
    Task<GamePlayer> GetAsync(int playerId);
    Task<IEnumerable<GamePlayer>> GetAllAsync();
    
    Task AddAsync(GamePlayer  player);
    Task UpdateAsync(GamePlayer  player);
    Task DeleteAsync(GamePlayer  player);
}