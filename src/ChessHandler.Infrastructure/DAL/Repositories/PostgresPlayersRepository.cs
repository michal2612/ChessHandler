using ChessHandler.Core.Entities;
using ChessHandler.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChessHandler.Infrastructure.DAL.Repositories;

internal sealed class PostgresPlayersRepository(PostgresDbContext context) : IPlayersRepository
{
    private readonly DbSet<Player> _players = context.Players;
    
    public async Task<Player> GetByUsernameAsync(string username)
        => await _players.SingleOrDefaultAsync(p => p.Name == username);

    public async Task AddAsync(Player player)
    {
        await _players.AddAsync(player);
        await context.SaveChangesAsync();
    }
}