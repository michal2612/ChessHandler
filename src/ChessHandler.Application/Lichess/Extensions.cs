using ChessHandler.Application.DTO;
using ChessHandler.Application.Exceptions;
using ChessHandler.Core.Entities;
using Game = LichessNET.Entities.Game.Game;

namespace ChessHandler.Application.Lichess;

public static class Extensions
{
    public static GameDto ToDto(this Game game)
    {
        return new()
        {
            Rated = true, // TODO
            White = new(),
            Black = new(),
            Result = game.Result.ToResult(),
            Format = GameFormat.Blitz,
            Moves = game.Moves.OriginalPgn
        };
    }

    public static GameResult ToResult(this LichessNET.Entities.Enumerations.GameResult result)
    {
        return result switch
        {
            LichessNET.Entities.Enumerations.GameResult.WhiteVictory => GameResult.White,
            LichessNET.Entities.Enumerations.GameResult.BlackVictory => GameResult.Black,
            LichessNET.Entities.Enumerations.GameResult.Stalemate => GameResult.Draw,
            _ => throw new InvalidResultException(result.ToString())
        };
    }
}