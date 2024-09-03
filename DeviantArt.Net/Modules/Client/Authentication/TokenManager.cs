using DeviantArt.Net.Models;
using DeviantArt.Net.Modules.TokenStore;

namespace DeviantArt.Net.Modules.Client.Authentication;

internal class TokenManager(ITokenStore tokenStore, DeviantArtOAuthClient oauthClient)
{
    internal async Task<DeviantArtAccessToken> AcquireTokenAsync(GrantType grantType)
    {
       return await AcquireTokenAsync(grantType, null);
    }

    internal async Task<DeviantArtAccessToken> AcquireTokenAsync(GrantType grantType, string? redirectUri)
    {
        var currentToken = await tokenStore.GetTokenAsync();
        if (currentToken is null)
        {
            return await GenerateTokenAsync(grantType, redirectUri);
        }
        if (currentToken?.HasTokenExpired() == false && currentToken?.GrantType == grantType)
        {
            return currentToken;
        }

        return await RefreshTokenAsync(grantType, redirectUri);
    }
    private async Task<DeviantArtAccessToken> RefreshTokenAsync(GrantType grantType, string? redirectUri)
    {
        var accessToken = await oauthClient.GetClientCredentialTokenAsync();
        var storedToken = await tokenStore.StoreTokenAsync(accessToken);
        return storedToken;
    }
    
    private async Task<DeviantArtAccessToken> GenerateTokenAsync(GrantType grantType, string? redirectUri)
    {
        var accessToken = grantType switch
        {
            GrantType.ClientCredentials => await oauthClient.GetClientCredentialTokenAsync(),
            GrantType.AuthorizationCode => await oauthClient.GetAuthorizationCodeAsync(),
            GrantType.Implicit => await oauthClient.GetImplicitTokenAsync(),
            _ => null
        };
        var storedToken = await tokenStore.StoreTokenAsync(accessToken!);
        return storedToken;
    }
}