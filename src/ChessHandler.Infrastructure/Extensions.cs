using ChessHandler.Infrastructure.DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChessHandler.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInstrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPostgres(configuration);
        
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
}