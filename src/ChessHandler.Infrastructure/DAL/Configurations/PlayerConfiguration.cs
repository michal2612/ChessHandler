using ChessHandler.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChessHandler.Infrastructure.DAL.Configurations;

public class PlayerConfiguration : IEntityTypeConfiguration<GamePlayer>
{
    public void Configure(EntityTypeBuilder<GamePlayer> builder)
    {
        builder.HasKey(g => g.Id);
        builder.HasIndex(g => g.Name)
            .HasDatabaseName("IDX_GamePlayer_Name")
            .IsUnique(false);
    }
}