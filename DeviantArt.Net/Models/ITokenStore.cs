namespace DeviantArt.Net.Models;

public interface ITokenStore
{
    Task<DeviantArtAccessToken> GetTokenAsync();
    Task<DeviantArtAccessToken> StoreTokenAsync(DeviantArtAccessToken token);
}