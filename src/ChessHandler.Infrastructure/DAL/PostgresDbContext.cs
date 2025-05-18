using ChessHandler.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChessHandler.Infrastructure.DAL;

internal sealed class PostgresDbContext : DbContext
{
    public DbSet<Game> Games { get; set; }

    public DbSet<Player> Players { get; set; }

    public PostgresDbContext(DbContextOptions<PostgresDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}