using ChessHandler.Application.DTO;
using MediatR;

namespace ChessHandler.Application.Members.Queries.GetUserGames;

public class GetUserGamesQueryHandler : IRequestHandler<GetUserGamesQuery, IEnumerable<GameDto>>
{
    public Task<IEnumerable<GameDto>> Handle(GetUserGamesQuery request, CancellationToken _)
    {
        throw new NotImplementedException();
    }
}