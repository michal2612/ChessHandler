using ChessHandler.Core.Repositories;
using ChessHandler.Infrastructure.Lichess;
using MediatR;

namespace ChessHandler.Application.Members.Commands.AddGame;

public class UpdateLichessGamesCommandHandler(IGamesRepository gamesRepository, ILichessClient  lichessClient)
    : IRequestHandler<UpdateLichessGamesCommand>
{
    public async Task Handle(UpdateLichessGamesCommand request, CancellationToken _)
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