using ChessHandler.Core.Entities;
using ChessHandler.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChessHandler.Infrastructure.DAL.Repositories;

public class PostgresGamesRepository : ILichessGameRepository
{
    private readonly DbSet<Game> _games;

    public PostgresGamesRepository(LichessGamesDbContext dbContext)
    {
        _games = dbContext.Games;
    }

    public async Task<Game> GetAsync(int gameId)
        => await _games.SingleOrDefaultAsync(g => g.Id == gameId);

    public async Task<IEnumerable<Game>> GetAllAsync(DateTime since, uint max = 100)
        => await _games.Take((int)max).ToListAsync();

    public async Task AddAsync(Game game) => await _games.AddAsync(game);
}