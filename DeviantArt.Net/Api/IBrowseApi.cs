namespace DeviantArt.Net.Api;

internal partial interface IDeviantArtApi
{
    [Get("/api/v1/oauth2/browse/dailydeviations")]
    Task<DeviantArtApiResponse<Deviation>> GetDailyDeviationsAsync([AliasAs("date")] DateOnly date, 
        [AliasAs("with_session")] bool withSession = false, [AliasAs("mature_content")] bool matureContent = false);
}