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

            if (service.Database.CanConnect())
            {
                service.Database.Migrate();
            }
            else
            {
                throw new DbConnectionFailed($"Cannot connect to database.");
            }
            
            return Task.CompletedTask;
        }
    }