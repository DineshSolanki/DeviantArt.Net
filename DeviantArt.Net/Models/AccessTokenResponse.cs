﻿using System.Text.Json.Serialization;

namespace DeviantArt.Net.Models;

public class DeviantArtAccessToken : ErrorResponse
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }

    [JsonPropertyName("token_type")]
    public string TokenType { get; set; }

    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }
    
    
    public DateTimeOffset TokenAcquiredAt { get; set; }

    public bool HasTokenExpired()
    {
        return (DateTimeOffset.UtcNow - TokenAcquiredAt).TotalSeconds > ExpiresIn;
    }
}