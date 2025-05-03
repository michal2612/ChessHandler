using ChessHandler.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChessHandler.Infrastructure.DAL;

public sealed class LichessGamesDbContext : DbContext
{
    public DbSet<Game> Games { get; set; }

    public DbSet<GamePlayer> Players { get; set; }

    public LichessGamesDbContext(DbContextOptions<LichessGamesDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}