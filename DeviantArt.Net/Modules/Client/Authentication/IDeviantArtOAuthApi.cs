using DeviantArt.Net.Models;
using Refit;

namespace DeviantArt.Net.Modules.Client.Authentication;

internal interface IDeviantArtOAuthApi
{
    [Post("/oauth2/token")]
    Task<DeviantArtAccessToken> GetOAuth2Token([Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, string> data);
}