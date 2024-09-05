using System;
using System.Text.Json;

namespace DeviantArt.Net.Exceptions;

public class DeviantArtApiException : Exception
{
    public HttpStatusCode StatusCode { get; }
    public string? ResponseContent { get; }
    public ErrorResponse? ErrorResponse { get; }

    public DeviantArtApiException(HttpStatusCode statusCode, string? responseContent)
        : base($"API request failed with status code {statusCode}: {responseContent}")
    {
        StatusCode = statusCode;
        ResponseContent = responseContent;
        if (ResponseContent is null) return;
        try
        {
            ErrorResponse = JsonSerializer.Deserialize<ErrorResponse>(ResponseContent);
        }
        catch (JsonException)
        {
                
        }

    }

    protected DeviantArtApiException(HttpStatusCode statusCode, ErrorResponse errorResponse)
        : base($"API request failed with status code {statusCode}: {errorResponse.ErrorDescription}")
    {
        StatusCode = statusCode;
        ErrorResponse = errorResponse;
    }
}

public class UnauthorizedException(string? responseContent)
    : DeviantArtApiException(HttpStatusCode.Unauthorized, responseContent);
    
public class RateLimitException(string responseContent)
    : DeviantArtApiException(HttpStatusCode.TooManyRequests, responseContent);

public class ServerErrorException(string responseContent)
    : DeviantArtApiException(HttpStatusCode.InternalServerError, responseContent);

public class ServiceUnavailableException(string responseContent)
    : DeviantArtApiException(HttpStatusCode.ServiceUnavailable, responseContent);
    
public class InvalidClientException(string responseContent)
    : DeviantArtApiException(HttpStatusCode.BadRequest, responseContent);
    
public class InsufficientScopeException : DeviantArtApiException
{
    public InsufficientScopeException(string responseContent) : base(HttpStatusCode.Forbidden, responseContent)
    {
    }
    
    public InsufficientScopeException(ErrorResponse errorResponse) : base(HttpStatusCode.Forbidden, errorResponse)
    {
    }
}