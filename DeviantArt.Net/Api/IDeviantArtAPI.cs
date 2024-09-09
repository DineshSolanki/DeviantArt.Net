namespace DeviantArt.Net.Api;

internal partial interface IDeviantArtApi
{
    [Get("/api/v1/oauth2/placebo")]
    Task<PlaceboResponse> CheckTokenValidityAsync();
    
}