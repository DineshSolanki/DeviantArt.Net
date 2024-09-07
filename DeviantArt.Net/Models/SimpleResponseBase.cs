namespace DeviantArt.Net.Models;

public class SimpleResponseBase
{
    [JsonPropertyName("error_description")]
    public string? ErrorDescription { get; init; }
    
    [JsonPropertyName("success")]
    public bool Success { get; init; }
    
}