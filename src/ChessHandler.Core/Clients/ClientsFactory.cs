using LichessNET.API;

namespace ChessHandler.Core.Clients;

public class ClientsFactory : IClientsFactory
{
    public LichessApiClient CreateClient(string token)
    {
        var client = new LichessApiClient();
        client.SetToken(token);
        return client;
    }
}