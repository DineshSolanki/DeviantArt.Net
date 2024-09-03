namespace DeviantArt.Net.Api;

public partial class Client
{
    public async Task<DeviantArtApiResponse<Deviation>> GetDailyDeviationsAsync(DateOnly date, bool withSession = false, bool matureContent = false)
    {
        return await _api.GetDailyDeviationsAsync(date, withSession, matureContent);
    }
}