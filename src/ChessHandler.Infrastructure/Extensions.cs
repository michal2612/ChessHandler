using ChessHandler.Infrastructure.DAL;
using ChessHandler.Infrastructure.NRedisStackExchange;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChessHandler.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInstrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddPostgres(configuration)
            .AddRedis(configuration);
        
        return services;
    }
    
    public static T GetOptions<T>(this IConfiguration configuration, string sectionName)
        where T : class, new()
    {
        var options = new T();
        var section = configuration.GetRequiredSection(sectionName);
        section.Bind(options);
        
        return options;
    }

    private static IServiceCollection AddRedis(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMemoryCache();
        
        var redisConfig = configuration.GetOptions<RedisConfiguration>("redis");

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = redisConfig.ConnectionString;
            options.InstanceName = "ChessHandler_";
        });

        return services;
    }
}