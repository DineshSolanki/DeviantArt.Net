using DeviantArt.Net.Models;

namespace DeviantArt.Net.Modules.TokenStore;

public interface ITokenStore
{
    Task<DeviantArtAccessToken?> GetTokenAsync();
    Task<DeviantArtAccessToken> StoreTokenAsync(DeviantArtAccessToken token);
}