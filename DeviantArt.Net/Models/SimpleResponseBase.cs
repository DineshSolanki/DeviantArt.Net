namespace DeviantArt.Net.Models;

public class SimpleResponseBase
{
    [JsonPropertyName("success")]
    public bool Success { get; init; }
}