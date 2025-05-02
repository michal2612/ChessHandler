using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChessHandler.Infrastructure.DAL;

internal static class Extensions
{
    private const string OptionsSectionName = "postgres";

    public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<PostgresOptions>(configuration.GetRequiredSection(OptionsSectionName));

        var postgresOptions = configuration.GetOptions<PostgresOptions>(OptionsSectionName);

        services.AddDbContext<LichessGamesDbContext>
            (ctx => ctx.UseNpgsql(postgresOptions.ConnectionString));
        
        return services;
    }
}