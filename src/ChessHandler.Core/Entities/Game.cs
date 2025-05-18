namespace ChessHandler.Core.Entities;

public class Game
{
    public int Id { get; set; }
    public bool Rated { get; set; }
    public int WhiteId { get; set; }
    public Player White { get; set; } = null!;
    public int BlackId { get; set; }
    public Player Black { get; set; } = null!;
    public Result Result { get; set; }
    public Format Format { get; set; }
    public string Moves { get; set; } = null!;
    public Source Source { get; set; }
    public int WhiteRating { get; set; }
    public int BlackRating { get; set; }
    public DateTime PlayedAt { get; set; }
}