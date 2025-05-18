using ChessHandler.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChessHandler.Infrastructure.DAL.Configurations;

public class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.HasKey(g => g.Id);
        builder.HasIndex(g => g.Name)
            .HasDatabaseName("IDX_GamePlayer_Name")
            .IsUnique(false);
        builder.Property(g => g.Title)
            .HasConversion(g => g.ToString(), g => Enum.Parse<Title>(g));
    }
}