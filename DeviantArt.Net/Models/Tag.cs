namespace DeviantArt.Net.Models;

public class Tag
{
    [JsonPropertyName("tag_name")]
    public string TagName { get; set; }
}