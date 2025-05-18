using ChessHandler.Core.Repositories;
using ChessHandler.Infrastructure.Lichess;
using MediatR;

namespace ChessHandler.Application.Members.Commands.AddGame;

public class UpdateLichessGamesHandler(IGamesRepository gamesRepository,ILichessClient  lichessClient)
    : IRequestHandler<UpdateLichessGames>
{
    public async Task Handle(UpdateLichessGames request, CancellationToken _)
    {
        // add proper validation
        if (string.IsNullOrEmpty(request.Username))
            throw new ArgumentException();
        
        // to be optimized
        var games = await gamesRepository
            .GetAllAsync(DateTime.Now - TimeSpan.FromDays(10));

        var lastGame = games.Any() ? games.Last().PlayedAt : DateTime.MinValue; 

        var newGames = await lichessClient
            .GetUserGamesAsync(request.Username, lastGame, 50);

        foreach (var game in newGames) await gamesRepository.AddAsync(game);
    }
}