namespace ChessHandler.Infrastructure.Exceptions;

public class DbConnectionFailed(string message) : Exception(message);