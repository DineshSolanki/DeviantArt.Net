namespace DeviantArt.Net.Modules.Client.Authentication;

internal class TokenManager(ITokenStore tokenStore, DeviantArtOAuthClient oauthClient)
{
    
    internal async Task<DeviantArtAccessToken> AcquireTokenAsync(GrantType grantType, Scope[] scopes)
    {
        var currentToken = await tokenStore.GetTokenAsync();
        var currentScopes = currentToken?.Scope.Split(' ').Select(s => s.Trim()).ToList();
        if (currentToken is null || !scopes.All(scope => currentScopes.Contains(scope.GetDescription())))
        {
            return await GenerateTokenAsync(grantType);
        }
        if (currentToken.HasTokenExpired() == false)
        {
            return currentToken;
        }

        return await GenerateTokenAsync(GrantType.RefreshToken, currentToken);
        
    }
    
    private async Task<DeviantArtAccessToken> GenerateTokenAsync(GrantType grantType, DeviantArtAccessToken? currentToken = null)
    {
        var accessToken = grantType switch
        {
            GrantType.ClientCredentials => await oauthClient.GetClientCredentialTokenAsync(),
            GrantType.AuthorizationCode => await oauthClient.GetAuthorizationCodeAsync(),
            GrantType.Implicit => await oauthClient.GetImplicitTokenAsync(),
            GrantType.RefreshToken => await oauthClient.RefreshAuthorizationCodeTokenAsync(
                currentToken ?? throw new ArgumentNullException(nameof(currentToken))),
            _ => throw new NotSupportedException("Grant type not supported")
        };
        var storedToken = await tokenStore.StoreTokenAsync(accessToken);
        return storedToken;
    }
}