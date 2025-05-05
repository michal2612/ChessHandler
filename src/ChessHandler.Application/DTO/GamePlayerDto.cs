using ChessHandler.Core.Entities;

namespace ChessHandler.Application.DTO;

public class GamePlayerDto
{
    public string Name { get; set; }

    public PlayerTitle Title { get; set; }

    public int Rating { get; set; }
}