using ChessHandler.Application.DTO;
using MediatR;

namespace ChessHandler.Application.Members.Queries.GetUserGames;

public class GetUserGamesHandler : IRequestHandler<GetUserGames, IEnumerable<GameDto>>
{
    public Task<IEnumerable<GameDto>> Handle(GetUserGames request, CancellationToken _)
    {
        throw new NotImplementedException();
    }
}