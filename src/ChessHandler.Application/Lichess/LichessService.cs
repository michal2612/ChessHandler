using ChessHandler.Application.DTO;
using LichessNET.API;

namespace ChessHandler.Application.Lichess;

public class LichessService
{
    private readonly LichessApiClient _client;
    
    public LichessService(string? token = null)
    {
        _client = new LichessApiClient();

        if (token != null)
        {
            _client.SetToken(token);
        }
    }
    
    public async Task<IEnumerable<GameDto>> GetGamesForUser(string userId, int max = 50)
    {
        var games = await _client.GetGamesAsync(userId, max);

        return games.Select(g => g.ToDto());
    }
}