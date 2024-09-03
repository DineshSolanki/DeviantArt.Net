using DeviantArt.Net.Client.Authentication;
using DeviantArt.Net.Exceptions;
using DeviantArt.Net.Models;
using DeviantArt.Net.Modules.TokenStore;
using Refit;

namespace DeviantArt.Net.Modules.Client;

internal class DeviantArtOAuthClient(string clientId, string clientSecret, ITokenStore tokenStore)
{
    private readonly string _clientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
    private readonly string _clientSecret = clientSecret ?? throw new ArgumentNullException(nameof(clientSecret));
    private readonly IDeviantArtOAuthApi _api = RestService.For<IDeviantArtOAuthApi>(Defaults.BaseAddress);
    private readonly ITokenStore _tokenStore = tokenStore ?? throw new ArgumentNullException(nameof(tokenStore));

    internal async Task<DeviantArtAccessToken> GetClientCredentialTokenAsync()
    {
        try
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
        catch (ApiException ex)
        {
            var contentType = ex.ContentHeaders?.ContentType?.MediaType;
            if (contentType != null && contentType.Contains("text/html"))
            {
                throw new InvalidClientException("Invalid client ID or secret.");
            }

            throw new DeviantArtApiException(ex.StatusCode, ex.Content);
        }
    }

    internal async Task<DeviantArtAccessToken> AcquireTokenAsync()
    {
        var token = await _tokenStore.GetTokenAsync();
        if (token?.HasTokenExpired() == false)
        {
            return token;
        }
        return await GetClientCredentialTokenAsync();
    }
}