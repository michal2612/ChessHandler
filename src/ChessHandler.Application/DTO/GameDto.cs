using ChessHandler.Core.Entities;

namespace ChessHandler.Application.DTO;

public class GameDto
{
    public bool Rated { get; set; }

    public GamePlayerDto White { get; set; } = null!;

    public GamePlayerDto Black { get; set; } = null!;
    
    public Result Result { get; set; }
    
    public Format Format { get; set; }

    public string Moves { get; set; }
    
    public DateTime PlayedAt { get; set; }
}