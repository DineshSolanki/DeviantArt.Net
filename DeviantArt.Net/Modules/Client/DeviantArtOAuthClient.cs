using DeviantArt.Net.Models;
using Refit;

namespace DeviantArt.Net.Client.Authentication;

public class DeviantArtOAuthClient
{
    private readonly string _clientId;
    private readonly string _clientSecret;
    private readonly IDeviantArtOAuthApi _api;
    private readonly ITokenStore _tokenStore;

    public DeviantArtOAuthClient(string clientId, string clientSecret, ITokenStore tokenStore)
    {
        _clientId = clientId;
        _clientSecret = clientSecret;
        _tokenStore = tokenStore;

        _api = RestService.For<IDeviantArtOAuthApi>("https://www.deviantart.com");
    }

    public async Task<DeviantArtAccessToken> GetClientCredentialTokenAsync()
    {
        var token = await _api.GetOAuth2Token(new Dictionary<string, string>
        {
            {"client_id", _clientId},
            {"client_secret", _clientSecret},
            {"grant_type", "client_credentials"}
        });
        token.TokenAcquiredAt = DateTimeOffset.UtcNow;
        await _tokenStore.StoreTokenAsync(token);
        return token;
    }

    public async Task<DeviantArtAccessToken> AcquireTokenAsync()
    {
        var token = await _tokenStore.GetTokenAsync();
        if (token?.HasTokenExpired() == false)
        {
            return token;
        }
        return await GetClientCredentialTokenAsync();
    }
}