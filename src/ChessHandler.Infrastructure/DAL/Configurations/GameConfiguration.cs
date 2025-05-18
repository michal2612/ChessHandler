using ChessHandler.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChessHandler.Infrastructure.DAL.Configurations;

internal sealed class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasKey(g => g.Id);
        builder.Property(g => g.Format)
            .HasConversion(g => g.ToString(), g => Enum.Parse<Format>(g));
        builder.Property(g => g.Result)
            .HasConversion(g => g.ToString(), g => Enum.Parse<Result>(g));
        builder.Property(g => g.Source)
            .HasConversion(g => g.ToString(), g => Enum.Parse<Source>(g));
        
        builder.HasOne(g => g.White)
            .WithMany()
            .HasForeignKey(g => g.WhiteId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(g => g.Black)
            .WithMany()
            .HasForeignKey(g => g.BlackId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
