namespace DeviantArt.Net.Models.User;

internal class WatchResponse
{
    [JsonPropertyName("watching")]
    public bool Watching { get; init; }
}