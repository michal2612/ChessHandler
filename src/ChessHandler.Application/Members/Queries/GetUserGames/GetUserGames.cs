using ChessHandler.Application.DTO;
using MediatR;

namespace ChessHandler.Application.Members.Queries.GetUserGames;

public sealed record GetUserGames(string username, int max) : IRequest<IEnumerable<GameDto>>;