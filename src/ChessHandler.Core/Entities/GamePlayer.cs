namespace ChessHandler.Core.Entities;

public class GamePlayer
{
    public int Id { get; set; }
    
    public string Name { get; }

    public PlayerTitle Title { get; }

    public int Rating { get; }
}