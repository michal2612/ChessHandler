using System.Net.Http.Headers;
using System.Text.Json;
using ChessHandler.Core.Entities;
using ChessHandler.Core.Repositories;

namespace ChessHandler.Infrastructure.Lichess;

internal sealed class LichessClient : ILichessClient
{
    private IPlayersRepository _playersRepository;
    
    private const string ApiBaseUrl = "https://lichess.org";

    public string Token { get; set; }

    private readonly HttpClient _httpClient = new()
    {
        BaseAddress = new Uri(ApiBaseUrl)
    };

    public LichessClient(IPlayersRepository playersRepository)
    {
        _playersRepository = playersRepository;
        Token = Environment.GetEnvironmentVariable("LICHESS_TOKEN") ?? string.Empty;
        
        _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/x-ndjson"));
        
        _httpClient.DefaultRequestHeaders.Authorization
            = new AuthenticationHeaderValue("Bearer", Token);
    }
    
    public async Task<IEnumerable<Game>> GetUserGamesAsync(string username, DateTime since, int max)
    {
        var ticks = since.Ticks;
        
        var result = await _httpClient
            .GetAsync($"/api/games/user/{username}?max={max}&since={since.Ticks}");
        
        if (!result.IsSuccessStatusCode)
            throw new ArgumentException($"Can't connect to {ApiBaseUrl} with status code {result.StatusCode}");
        
        var responseContent = await result.Content.ReadAsStringAsync();
        
        var lines = responseContent.Split(["\n"], StringSplitOptions.RemoveEmptyEntries);
        var games = new Game[lines.Length];

        for (var lineIndex = 0; lineIndex < lines.Length; lineIndex++)
        {
            var game = new  Game();
            var jsonDoc = JsonDocument.Parse(lines[lineIndex]);
            
            game.Rated = jsonDoc.RootElement.GetProperty("rated").GetBoolean();
            game.Moves = jsonDoc.RootElement.GetProperty("moves").ToString();
            game.Format = GetFormat(jsonDoc.RootElement.GetProperty("speed").GetString() ?? string.Empty);
            game.PlayedAt = DateTimeOffset
                .FromUnixTimeMilliseconds(jsonDoc.RootElement.GetProperty("lastMoveAt").GetInt64()).UtcDateTime;
            await ResolvePlayers(game, jsonDoc.RootElement.GetProperty("players"));

            game.Source = Source.Lichess;
            game.WhiteRating = jsonDoc.RootElement.GetProperty("players").GetProperty("white").GetProperty("rating").GetInt32();
            game.BlackRating = jsonDoc.RootElement.GetProperty("players").GetProperty("black").GetProperty("rating").GetInt32();

            games[lineIndex] = game;
        }

        return games;
    }

    private async Task ResolvePlayers(Game game, JsonElement playersElement)
    {
        game.WhiteId = await HandlePlayer(playersElement.GetProperty("white").GetProperty("user"));
        game.BlackId = await HandlePlayer(playersElement.GetProperty("black").GetProperty("user"));
        return;

        async Task<int> HandlePlayer(JsonElement playerElement)
        {
            var name = playerElement.GetProperty("name").GetString();
            var dbPlayer = await _playersRepository.GetByUsernameAsync(name);
            if (dbPlayer == null)
            {
                await _playersRepository.AddAsync(new()
                {
                    Name = name,
                    Title = Title.None
                });
                dbPlayer = await _playersRepository.GetByUsernameAsync(name);
            }
            return dbPlayer.Id;
        }
    }

    private async Task<Player> GetPlayer(JsonElement json)
    {
        var name = json.GetProperty("user").GetProperty("name").GetString() ?? string.Empty;
        var dbPlayer = await _playersRepository.GetByUsernameAsync(name);
        if (dbPlayer == null)
        {
            return new Player()
            {
                Name = name,
                Title = Title.None
            };
        }

        return dbPlayer;
    }

    private Format GetFormat(string format)
    {
        return format switch
        {
            "blitz" => Format.Blitz,
            _ => throw new ArgumentException($"Can't parse format {format}")
        };
    }
}