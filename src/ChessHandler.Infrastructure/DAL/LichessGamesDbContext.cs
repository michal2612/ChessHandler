using LichessNET.Entities.Game;
using Microsoft.EntityFrameworkCore;

namespace ChessHandler.Infrastructure.DAL;

internal sealed class LichessGamesDbContext : DbContext
{
    public DbSet<IEnumerable<Game>> Games { get; set; }

    public LichessGamesDbContext(DbContextOptions<LichessGamesDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}