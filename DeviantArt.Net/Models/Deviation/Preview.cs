namespace DeviantArt.Net.Models.Deviation;

public class Preview
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