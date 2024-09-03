using DeviantArt.Net.Api.Handler;
using DeviantArt.Net.Modules;
using DeviantArt.Net.Modules.Util.Formatters;

namespace DeviantArt.Net.Api;

public class Client
{
    private readonly IDeviantArtApi _api;

    public Client(string clientId, string clientSecret, ITokenStore tokenStore)
        : this(new DeviantArtOAuthClient(clientId, clientSecret, tokenStore))
    {
    }
    
    public Client(string clientId, string clientSecret, ITokenStore tokenStore, string redirectUri, Scope scope)
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

        _api = RestService.For<IDeviantArtApi>(httpClient);
    }
    
    public Task<PlaceboResponse> IsTokenValidAsync()
    {
        return _api.CheckTokenValidityAsync();
    }

    public async Task<Deviation> GetDeviationAsync(string deviationId)
    {
        try
        {
            return await _api.GetDeviationAsync(deviationId);
        }
        catch (ApiException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
        {
            throw new UnauthorizedException(ex.Content);
        }
        catch (ApiException ex)
        {
            throw new DeviantArtApiException(ex.StatusCode, ex.Content);
        }
    }

    public async Task<Deviation> GetDeviationAsync(Deviation deviation)
    {
        return await GetDeviationAsync(deviation.DeviationId);
    }

    public async Task<DeviantArtApiResponse<Deviation>> BrowseHomeDeviationsAsync(int limit, int offset, bool matureContent)
    {
        try
        {
            return await _api.GetHomeDeviationsAsync(limit, offset, matureContent);
        }
        catch (ApiException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
        {
            throw new UnauthorizedException(ex.Content);
        }
        catch (ApiException ex)
        {
            throw new DeviantArtApiException(ex.StatusCode, ex.Content);
        }
    }
    
    public async Task<BrowseTagsResponse> BrowseTagsAsync(
        string tag, 
        string? cursor = null, 
        int? offset = null, 
        int? limit = null, 
        bool? withSession = null,
        bool? matureContent = null)
    {
        try
        {
            return await _api.BrowseTagsAsync(tag, cursor, offset, limit, withSession, matureContent);
        }
        catch (ApiException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
        {
            throw new UnauthorizedException(ex.Content);
        }
        catch (ApiException ex)
        {
            throw new DeviantArtApiException(ex.StatusCode, ex.Content);
        }
    }
    
}