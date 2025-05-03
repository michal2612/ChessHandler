using Microsoft.Extensions.DependencyInjection;

namespace ChessHandler.Application;

public static class Extensions
{
    public static IServiceCollection AddApp(this IServiceCollection services)
    {
        return services;
    }
}