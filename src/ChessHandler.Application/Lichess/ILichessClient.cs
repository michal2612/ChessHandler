using ChessHandler.Core.Entities;

namespace ChessHandler.Infrastructure.Lichess;

public interface ILichessClient
{
    Task<IEnumerable<Game>> GetUserGamesAsync(string username,  DateTime since, int max);

    public string Token { get; set; }
}