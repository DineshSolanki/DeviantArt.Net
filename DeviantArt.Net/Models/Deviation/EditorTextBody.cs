namespace DeviantArt.Net.Models.Deviation;

public class EditorTextBody
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("markup")]
    public string Markup { get; set; }

    [JsonPropertyName("features")]
    public string Features { get; set; }
}