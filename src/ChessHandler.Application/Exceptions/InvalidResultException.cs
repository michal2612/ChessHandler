namespace ChessHandler.Application.Exceptions;

public class InvalidResultException(string result) : 
    ApplicationException("invalid_game_result", $"Given result {result} is not valid.");