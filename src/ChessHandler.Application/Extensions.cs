using ChessHandler.Application.Members.Commands.AddGame;
using ChessHandler.Infrastructure.Lichess;
using Microsoft.Extensions.DependencyInjection;

namespace ChessHandler.Application;

public static class Extensions
{
    public static IServiceCollection AddApp(this IServiceCollection services)
    {
        services.AddScoped<ILichessClient, LichessClient>();
        
        services.AddMediatR(cfg 
            => cfg.RegisterServicesFromAssembly(typeof(UpdateLichessGamesHandler).Assembly));
        return services;
    }
}