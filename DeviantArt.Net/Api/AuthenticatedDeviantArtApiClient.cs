using DeviantArt.Net.Client.Authentication;
using DeviantArt.Net.Models;
using Refit;

namespace DeviantArt.Net.Api;

public class AuthenticatedDeviantArtApiClient
{
    private readonly IDeviantArtApi _api;
    private readonly DeviantArtOAuthClient _oauthClient;

    public AuthenticatedDeviantArtApiClient(DeviantArtOAuthClient oauthClient)
    {
        _oauthClient = oauthClient;

        var httpClient = new HttpClient(new AuthenticatedHttpClientHandler(_oauthClient))
        {
            BaseAddress = new Uri("https://www.deviantart.com")
        };

        _api = RestService.For<IDeviantArtApi>(httpClient);
    }
    public Task<PlaceboResponse> isTokenValidAsync()
    {
        return _api.CheckTokenValidityAsync();
    }

    public Task<Deviation> GetDeviationAsync(string deviationId)
    {
        return _api.GetDeviationAsync(deviationId);
    }

    public Task<DeviantArtApiResponse<Deviation>> GetNewestDeviationsAsync(int limit, int offset, bool matureContent)
    {
        return _api.GetHomeDeviationsAsync(limit, offset, matureContent);
    }
    
    public Task<BrowseTagsResponse> BrowseTagsAsync(
        string tag, 
        string? cursor = null, 
        int? offset = null, 
        int? limit = null, 
        bool? withSession = null,
        bool? matureContent = null)
    {
        return _api.BrowseTagsAsync(tag, cursor, offset, limit, withSession, matureContent);
    }
    
}