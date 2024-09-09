namespace DeviantArt.Net.Models.Deviation;

public class EditorText
{
    [JsonPropertyName("excerpt")]
    public string Excerpt { get; set; }

    [JsonPropertyName("body")]
    public EditorTextBody Body { get; set; }
}