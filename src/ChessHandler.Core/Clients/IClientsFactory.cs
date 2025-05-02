using LichessNET.API;

namespace ChessHandler.Core.Clients;

public interface IClientsFactory
{
    public LichessApiClient CreateClient(string token);
}