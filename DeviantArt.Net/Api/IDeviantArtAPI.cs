using DeviantArt.Net.Models;
using Refit;

namespace DeviantArt.Net.Api;

internal interface IDeviantArtApi
{
    [Get("/api/v1/oauth2/placebo")]
    Task<PlaceboResponse> CheckTokenValidityAsync();
    
    [Get("/api/v1/oauth2/deviation/{deviationId}")]
    Task<Deviation> GetDeviationAsync(string deviationId);

    [Get("/api/v1/oauth2/browse/home")]
    Task<DeviantArtApiResponse<Deviation>> GetHomeDeviationsAsync([AliasAs("limit")] int limit, [AliasAs("offset")] int offset, [AliasAs("mature_content")] bool matureContent);
    
    [Get("/api/v1/oauth2/browse/tags")]
    Task<BrowseTagsResponse> BrowseTagsAsync(
        [AliasAs("tag")] string tag,
        [AliasAs("cursor")] string? cursor = null,
        [AliasAs("offset")] int? offset = null,
        [AliasAs("limit")] int? limit = null,
        [AliasAs("with_session")] bool? withSession = null,
        [AliasAs("mature_content")] bool? matureContent = null);
}