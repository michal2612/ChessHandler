using ChessHandler.Core.Entities;

namespace ChessHandler.Application.DTO;

public class GamePlayerDto
{
    public string Name { get; }

    public PlayerTitle Title { get; }

    public int Rating { get; }
}