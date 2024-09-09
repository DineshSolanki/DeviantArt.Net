namespace DeviantArt.Net.Models.Deviation;

public class Thumbnail
{
    [JsonPropertyName("src")]
    public string Src { get; set; }

    [JsonPropertyName("height")]
    public int Height { get; set; }

    [JsonPropertyName("width")]
    public int Width { get; set; }

    [JsonPropertyName("transparency")]
    public bool Transparency { get; set; }
}