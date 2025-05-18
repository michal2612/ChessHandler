using ChessHandler.Core.Entities;

namespace ChessHandler.Core.Repositories;

public interface IPlayersRepository
{
    Task<Player> GetByUsernameAsync(string username);
    
    Task AddAsync(Player player);
}