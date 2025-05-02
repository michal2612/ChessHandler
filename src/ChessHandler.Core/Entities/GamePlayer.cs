namespace ChessHandler.Core.Entities;

public class GamePlayer(string name, PlayerTitle title, int rating)
{
    public int Id { get; set; }
    
    public string Name { get; } = name;

    public PlayerTitle Title { get; } = title;

    public int Rating { get; } = rating;
}