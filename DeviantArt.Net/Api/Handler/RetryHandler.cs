using System.Text.Json;

namespace DeviantArt.Net.Api.Handler;

internal class RetryHandler(HttpMessageHandler innerHandler) : DelegatingHandler(innerHandler)
{
    private const int MaxRetries = 3;
    private const int InitialDelay = 1000; // Initial delay in milliseconds

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var retryCount = 0;
        var delay = InitialDelay;

        while (true)
        {
            try
            {
                var response = await base.SendAsync(request, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                if (response.StatusCode == HttpStatusCode.InternalServerError && retryCount < MaxRetries)
                {
                    retryCount++;
                    await Task.Delay(delay, cancellationToken);
                    delay *= 2; // Exponential backoff
                    continue;
                }

                await HandleApiErrorAsync(response);
                return response; // This line will not be reached because HandleApiErrorAsync will throw
            }
            catch (HttpRequestException) when (retryCount < MaxRetries)
            {
                retryCount++;
                await Task.Delay(delay, cancellationToken);
                delay *= 2; // Exponential backoff
            }
        }
    }

    private static async Task HandleApiErrorAsync(HttpResponseMessage response)
    {
        var contentType = response.Content.Headers.ContentType?.MediaType;
        var content = await response.Content.ReadAsStringAsync();

        if (contentType != null && contentType.Contains("text/html"))
        {
            throw new InvalidClientException("Invalid client ID or secret.");
        }

        
        switch (response.StatusCode)
        {
            case HttpStatusCode.Unauthorized:
                throw new UnauthorizedException(content);
            case HttpStatusCode.TooManyRequests:
                throw new RateLimitException(content);
            case HttpStatusCode.ServiceUnavailable:
                throw new ServiceUnavailableException(content);
            case HttpStatusCode.Forbidden:
            {
                var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(content);
                if (errorResponse?.ErrorType == CustomExceptionCode.InsufficientScope)
                {
                    throw new InsufficientScopeException(errorResponse);
                }

                throw new DeviantArtApiException(response.StatusCode, content);
            }
            default:
                throw new DeviantArtApiException(response.StatusCode, content);
        }
    }
}