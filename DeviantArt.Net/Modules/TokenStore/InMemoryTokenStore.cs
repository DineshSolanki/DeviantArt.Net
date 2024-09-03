using DeviantArt.Net.Models;
using DeviantArt.Net.Modules.TokenStore;

namespace DeviantArt.Net.Modules.Client.Authentication;

public sealed class InMemoryTokenStore : ITokenStore
{
    private static DeviantArtAccessToken CurrentToken { get; set; }

    public Task<DeviantArtAccessToken> StoreTokenAsync(DeviantArtAccessToken token)
    {
        CurrentToken = token;
        return Task.FromResult(token);
    }

    public Task<DeviantArtAccessToken> GetTokenAsync()
    {
        return Task.FromResult(CurrentToken);
    }
}