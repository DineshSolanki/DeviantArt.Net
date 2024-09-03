using System;
using System.Net;
using System.Text.Json;
using DeviantArt.Net.Models;

namespace DeviantArt.Net.Exceptions
{
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
    }

    public class UnauthorizedException(string? responseContent)
        : DeviantArtApiException(HttpStatusCode.Unauthorized, responseContent);
    
}