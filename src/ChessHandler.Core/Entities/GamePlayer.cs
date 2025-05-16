namespace ChessHandler.Core.Entities;

public class GamePlayer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public PlayerTitle Title { get; set; }

    public int Rating { get; set; }
}