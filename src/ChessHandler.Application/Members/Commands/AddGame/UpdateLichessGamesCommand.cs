using MediatR;

namespace ChessHandler.Application.Members.Commands.AddGame;

public sealed record UpdateLichessGamesCommand(string Username) : IRequest;
