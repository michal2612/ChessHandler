using MediatR;

namespace ChessHandler.Application.Members.Commands.AddGame;

public sealed record UpdateLichessGames(string Username) : IRequest;
