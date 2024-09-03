using DeviantArt.Net.Models;
using Refit;

namespace DeviantArt.Net.Client.Authentication;

using System.Collections.Generic;
using System.Threading.Tasks;

internal interface IDeviantArtOAuthApi
{
    [Post("/oauth2/token")]
    Task<DeviantArtAccessToken> GetOAuth2Token([Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, string> data);
}