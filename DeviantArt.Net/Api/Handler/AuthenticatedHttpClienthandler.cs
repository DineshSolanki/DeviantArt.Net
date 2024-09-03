using System.Net.Http.Headers;

namespace DeviantArt.Net.Api.Handler;

internal class AuthenticatedHttpClientHandler(DeviantArtOAuthClient oauthClient)
    : DelegatingHandler(new HttpClientHandler())
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = await oauthClient.AcquireTokenAsync();
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
        return await base.SendAsync(request, cancellationToken);
    }
}