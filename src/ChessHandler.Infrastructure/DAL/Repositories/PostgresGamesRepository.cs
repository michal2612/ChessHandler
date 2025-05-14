using ChessHandler.Core.Entities;
using ChessHandler.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChessHandler.Infrastructure.DAL.Repositories;

internal sealed class PostgresGamesRepository(LichessGamesDbContext dbContext)
    : IGamesRepository
{
    private readonly DbSet<Game> _games = dbContext.Games;

    public async Task<Game> GetAsync(int gameId)
        => await _games.SingleOrDefaultAsync(g => g.Id == gameId);

    public async Task<IEnumerable<Game>> GetAllAsync(DateTime since, uint max = 100)
        => await _games
            .Include(g => g.White)
            .Include(g => g.Black)
            .Take((int)max).
            ToListAsync();

    public async Task<IEnumerable<Game>> GetWithPaginationAsync(int page, int pageSize)
    {
        var games = await _games
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Include(g => g.White)
            .Include(g => g.Black)
            .ToListAsync();
        return games;
    }

    public async Task AddAsync(Game game)
    {
        await _games.AddAsync(game);
        await dbContext.SaveChangesAsync();
    }
}