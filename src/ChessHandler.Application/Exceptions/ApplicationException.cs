namespace ChessHandler.Application.Exceptions;

public class ApplicationException(string code, string message) : Exception(message)
{
    public string Code { get; set; } = code;
}