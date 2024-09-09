namespace DeviantArt.Net.Models;

public class Tag
{
    [JsonPropertyName("tag_name")]
    public string Name { get; set; }

    [JsonPropertyName("sponsored")]
    public bool Sponsored { get; set; }

    [JsonPropertyName("sponsor")]
    public string Sponsor { get; set; }
}