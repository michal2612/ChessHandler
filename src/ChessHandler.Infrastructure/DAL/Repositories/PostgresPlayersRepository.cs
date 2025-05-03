using ChessHandler.Core.Entities;
using ChessHandler.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChessHandler.Infrastructure.DAL.Repositories;

public class PostgresPlayersRepository : ILichessPlayerRepository
{
    private readonly DbSet<GamePlayer> _gamePlayers;

    public PostgresPlayersRepository(LichessGamesDbContext dbContext)
    {
        _gamePlayers = dbContext.Players;
    }
    
    public Task<GamePlayer> GetAsync(int playerId)
        => _gamePlayers.SingleOrDefaultAsync(g => g.Id == playerId);

    public async Task<IEnumerable<GamePlayer>> GetAllAsync() => await _gamePlayers.ToListAsync();

    public async Task AddAsync(GamePlayer player) => await _gamePlayers.AddAsync(player);
}