using System.Net;
using DeviantArt.Net.Client.Authentication;
using DeviantArt.Net.Exceptions;
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