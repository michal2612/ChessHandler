using ChessHandler.Core.Repositories;
using ChessHandler.Infrastructure.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChessHandler.Infrastructure.DAL;

internal static class Extensions
{
    private const string OptionsSectionName = "postgres";
    
    private const string UseInMemoryDatabase = "UseInMemoryDatabase";
    
    public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<PostgresOptions>(configuration.GetRequiredSection(OptionsSectionName));

        var postgresOptions = configuration.GetOptions<PostgresOptions>(OptionsSectionName);

        services.AddDbContext<PostgresDbContext>
            (ctx => ctx.UseNpgsql(postgresOptions.ConnectionString));

        services.AddHostedService<DbInitializer>();
        
        services.AddScoped<IGamesRepository, PostgresGamesRepository>();
        services.Decorate<IGamesRepository, CachedGamesRepository>();

        services.AddScoped<IPlayersRepository, PostgresPlayersRepository>();
        
        return services;
    }
}