namespace ChessHandler.Core.Entities;

public class Player
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public Title Title { get; set; }
}