    using ChessHandler.Infrastructure.Exceptions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    namespace ChessHandler.Infrastructure.DAL;

    public class DbInitializer(IServiceProvider serviceProvider) : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = serviceProvider.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<LichessGamesDbContext>();
            
            service.Database.Migrate();
            
            return Task.CompletedTask;
        }
    }