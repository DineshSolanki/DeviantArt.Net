using System.Diagnostics;
using System.Net;
using System.Web;
using DeviantArt.Net.Exceptions;
using DeviantArt.Net.Models;
using DeviantArt.Net.Modules.Client.Authentication;
using DeviantArt.Net.Modules.TokenStore;
using Refit;

namespace DeviantArt.Net.Modules.Client;

internal class DeviantArtOAuthClient
{
    private readonly string _clientId;
    private readonly string _clientSecret;
    private readonly IDeviantArtOAuthApi _api = RestService.For<IDeviantArtOAuthApi>(Defaults.BaseAddress);
    private readonly TokenManager _tokenManager;
    private readonly GrantType _grantType;
    private readonly string? _redirectUri;
    private readonly Scope _scope;
    private string? _authorizationCode;
    private const string ResponseString = "<html><body><h1>Authorization Successful</h1><p>You can close this window now.</p></body></html>";
    public DeviantArtOAuthClient(string clientId, string clientSecret, ITokenStore tokenStore)
        :this(clientId, clientSecret, tokenStore, null, Scope.Basic, GrantType.ClientCredentials)
    {
        
    }
    
    private DeviantArtOAuthClient(string clientId, string clientSecret, ITokenStore tokenStore, string? redirectUri,
        Scope scope, GrantType grantType)
    {
        _clientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
        _clientSecret = clientSecret ?? throw new ArgumentNullException(nameof(clientSecret));
        _tokenManager = new TokenManager(tokenStore ?? throw new ArgumentNullException(nameof(tokenStore)), this);
        _grantType = grantType;
        _redirectUri = redirectUri;
        _scope = scope;
    }
    public DeviantArtOAuthClient(string clientId, string clientSecret, ITokenStore tokenStore, string redirectUri,
        Scope scope = Scope.Basic): this(clientId, clientSecret, tokenStore, redirectUri, scope, GrantType.AuthorizationCode)
    {
        
    }

    internal async Task<DeviantArtAccessToken> GetClientCredentialTokenAsync()
    {
        return await RequestTokenAsync(new Dictionary<string, string>
        {
            {"client_id", _clientId},
            {"client_secret", _clientSecret},
            {"grant_type", GrantType.ClientCredentials.GetDescription()}
        });
    }
    
    internal async Task<DeviantArtAccessToken> RefreshAuthorizationCodeTokenAsync(DeviantArtAccessToken currentToken)
    {
        return await RequestTokenAsync(new Dictionary<string, string>
        {
            {"client_id", _clientId},
            {"client_secret", _clientSecret},
            {"grant_type", GrantType.RefreshToken.GetDescription()},
            {"refresh_token", currentToken.RefreshToken}
        });
    }
    
    internal async Task<DeviantArtAccessToken> GetAuthorizationCodeAsync()
    {
        var url = GetAuthorizationUrl(_scope.GetDescription());
        Process.Start(new ProcessStartInfo
        {
            FileName = url,
            UseShellExecute = true
        });
        var listener = new HttpListener();
        listener.Prefixes.Add(_redirectUri);
        listener.Start();
        var context = await listener.GetContextAsync();
        _authorizationCode = await HandleRedirectAsync(context.Request.Url?.ToString());
        
        
        var buffer = System.Text.Encoding.UTF8.GetBytes(ResponseString);
        context.Response.ContentLength64 = buffer.Length;
        var responseOutput = context.Response.OutputStream;
        await responseOutput.WriteAsync(buffer);
        responseOutput.Close();
        listener.Stop();
        return await GetAuthorizationCodeTokenAsync();
    }

    private async Task<DeviantArtAccessToken> GetAuthorizationCodeTokenAsync()
    {
        if (string.IsNullOrEmpty(_authorizationCode))
        {
            throw new InvalidOperationException("Authorization code is missing.");
        }

        return await RequestTokenAsync(new Dictionary<string, string>
        {
            {"client_id", _clientId},
            {"client_secret", _clientSecret},
            {"grant_type", GrantType.AuthorizationCode.GetDescription()},
            {"code", _authorizationCode},
            {"redirect_uri", _redirectUri ?? throw new InvalidOperationException()}
        });
    }

    private async Task<DeviantArtAccessToken> RequestTokenAsync(Dictionary<string, string> data)
    {
        try
        {
            var token = await _api.GetOAuth2Token(data);
            token.TokenAcquiredAt = DateTimeOffset.UtcNow;
            return token;
        }
        catch (ApiException ex)
        {
            HandleApiException(ex);
            return null!; // This will never be reached due to the exception being thrown above
        }
    }

    private static void HandleApiException(ApiException ex)
    {
        var contentType = ex.ContentHeaders?.ContentType?.MediaType;
        if (contentType != null && contentType.Contains("text/html"))
        {
            throw new InvalidClientException("Invalid client ID or secret.");
        }
        throw new DeviantArtApiException(ex.StatusCode, ex.Content);
    }
    private string GetAuthorizationUrl(string? scope = "basic", string? state = null)
    {
        var queryParams = new Dictionary<string, string?>
        {
            {"response_type", "code"},
            {"client_id", _clientId},
            {"redirect_uri", _redirectUri},
            {"scope", scope}
        };

        if (!string.IsNullOrEmpty(state))
        {
            queryParams.Add("state", state);
        }

        var queryString = string.Join("&", queryParams.Select(p => $"{p.Key}={HttpUtility.UrlEncode(p.Value)}"));
        return $"{Defaults.BaseAddress}/oauth2/authorize?{queryString}";
    }
    
    private static Task<string> HandleRedirectAsync(string? redirectUrl)
    {
        if (string.IsNullOrEmpty(redirectUrl))
        {
            throw new InvalidOperationException("Redirect URL is missing.");
        }
        var uri = new Uri(redirectUrl);
        var query = HttpUtility.ParseQueryString(uri.Query);
        var authCode = query["code"];

        if (!string.IsNullOrEmpty(authCode)) return Task.FromResult(authCode);
        var error = query["error"];
        var errorDescription = query["error_description"];
        throw new Exception($"Authorization failed: {error} - {errorDescription}");

    }


    internal async Task<DeviantArtAccessToken> AcquireTokenAsync()
    {
        return await _tokenManager.AcquireTokenAsync(_grantType);
    }

    public Task<DeviantArtAccessToken> GetImplicitTokenAsync()
    {
        throw new NotImplementedException("Implicit grant type is not supported.");
    }
}