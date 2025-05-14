using ChessHandler.Core.Entities;

namespace ChessHandler.Core.Repositories;

public interface IGamesRepository
{
    Task<Game> GetAsync(int gameId);
    Task<IEnumerable<Game>> GetAllAsync(DateTime since, uint max = 100);
    Task<IEnumerable<Game>> GetWithPaginationAsync(int page, int pageSize);
    Task AddAsync(Game game);
}