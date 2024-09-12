namespace DeviantArt.Net.Models;

public class TagNamesResponse
{
    [JsonPropertyName("results")]
    public List<Tag> Results { get; set; }
    
    [JsonPropertyName("session")]
    public ApiSession? Session { get; set; }
}