namespace DeviantArt.Net.Models.User;

public class DamnTokenResponse
{
    [JsonPropertyName("damntoken")]
    public string DamnToken { get; init; }
}