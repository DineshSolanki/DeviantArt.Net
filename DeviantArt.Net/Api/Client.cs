using DeviantArt.Net.Api.Handler;
using DeviantArt.Net.Modules;
using DeviantArt.Net.Modules.Util.Formatters;

namespace DeviantArt.Net.Api;

public partial class Client
{
    private readonly IDeviantArtApi _api;

    public Client(string clientId, string clientSecret, ITokenStore tokenStore)
        : this(new DeviantArtOAuthClient(clientId, clientSecret, tokenStore))
    {
    }
    
    public Client(string clientId, string clientSecret, ITokenStore tokenStore, string redirectUri,
        params Scope[] scope)
        : this(new DeviantArtOAuthClient(clientId, clientSecret, tokenStore, redirectUri, scope))
    {
    }
    private Client(DeviantArtOAuthClient oauthClient)
    {
        var handler = new AuthenticatedHttpClientHandler(oauthClient)
        {
            InnerHandler = new RetryHandler(new HttpClientHandler())
        };

        var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri(Defaults.BaseAddress)
        };
        var settings = new RefitSettings
        {
            UrlParameterFormatter = new CustomDateUrlParameterFormatter()
        };
        _api = RestService.For<IDeviantArtApi>(httpClient, settings);
    }
    
    public Task<PlaceboResponse> IsTokenValidAsync()
    {
        return _api.CheckTokenValidityAsync();
    }
}