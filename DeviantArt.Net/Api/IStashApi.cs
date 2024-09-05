using DeviantArt.Net.Models.Stash;

namespace DeviantArt.Net.Api;

internal partial interface IDeviantArtApi
{
    
    [Post("/api/v1/oauth2/stash/publish")]
    Task<PublishStashResponse> PublishStashAsync([Query]PublishStashRequest request);
}