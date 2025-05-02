namespace ChessHandler.Core.Entities;

public class Game
{
    public int Id { get; set; }

    public bool Rated { get; set; }

    public GamePlayer White { get; set; }

    public GamePlayer Black { get; set; }
    
    public GameResult Result { get; set; }

    public GameFormat Format { get; set; }

    public string Moves { get; set; }
}