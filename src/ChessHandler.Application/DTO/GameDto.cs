using ChessHandler.Core.Entities;

namespace ChessHandler.Application.DTO;

public class GameDto
{
    public bool Rated { get; set; }

    public GamePlayerDto White { get; set; }

    public GamePlayerDto Black { get; set; }
    
    public GameResult Result { get; set; }
    
    public GameFormat Format { get; set; }

    public string Moves { get; set; }
}