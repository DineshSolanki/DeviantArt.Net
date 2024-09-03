namespace DeviantArt.Net.Models;

public enum GrantType
{
    [Description("authorization_code")]
    AuthorizationCode,
    
    [Description("implicit")]
    Implicit,
    
    [Description("client_credentials")]
    ClientCredentials,
    
    [Description("refresh_token")]
    RefreshToken
}