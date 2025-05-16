using ChessHandler.Application;
using ChessHandler.Infrastructure.DAL;
using ChessHandler.Infrastructure.NRedisStackExchange;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace ChessHandler.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInstrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddPostgres(configuration)
            .AddApp()
            .AddNRedisStackExchangeRedis(configuration);
        
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

    private static IServiceCollection AddNRedisStackExchangeRedis(this IServiceCollection services,
        IConfiguration configuration)
    {
        var options = configuration
            .GetOptions<NRedisStackExchangeConfiguration>("NRedisStackExchange");
        
        var redisConfig = ConfigurationOptions
            .Parse(options.Configuration, true);

        services.AddSingleton<IConnectionMultiplexer>(sp => ConnectionMultiplexer.Connect(redisConfig));
        
        services.AddSingleton(serviceProvider =>
        {
            var multiplexer = serviceProvider.GetRequiredService<IConnectionMultiplexer>();
            return multiplexer.GetDatabase();
        });
        
        return services;
    }
}