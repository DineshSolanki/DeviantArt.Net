using System.Text.Json.Serialization;

namespace DeviantArt.Net.Models;

public class DeviantArtAccessToken
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }

    [JsonPropertyName("token_type")]
    public string TokenType { get; set; }

    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }

    [JsonPropertyName("error")]
    public string ErrorType { get; set; }

    [JsonPropertyName("error_description")]
    public string ErrorDescription { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }
    
    public DateTimeOffset TokenAcquiredAt { get; set; }

    public bool HasTokenExpired()
    {
        return (DateTimeOffset.UtcNow - TokenAcquiredAt).TotalSeconds > ExpiresIn;
    }
}