using DeviantArt.Net.Client.Authentication;
using DeviantArt.Net.Models;
using DeviantArt.Net.Modules.TokenStore;

namespace DeviantArt.Net.Modules.Client.Authentication;

internal class TokenManager(ITokenStore tokenStore, DeviantArtOAuthClient oauthClient)
{
    public async Task<DeviantArtAccessToken> AcquireTokenAsync()
    {
        var currentToken = await tokenStore.GetTokenAsync();
        if (currentToken?.HasTokenExpired() == false)
        {
            return currentToken;
        }

        return await RefreshTokenAsync();
    }

    private async Task<DeviantArtAccessToken> RefreshTokenAsync()
    {
        var accessToken = await oauthClient.GetClientCredentialTokenAsync();
        var storedToken = await tokenStore.StoreTokenAsync(accessToken);
        return storedToken;
    }
}