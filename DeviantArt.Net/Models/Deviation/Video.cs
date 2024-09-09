namespace DeviantArt.Net.Models.Deviation;

public class Video
{
    [JsonPropertyName("src")]
    public string Src { get; set; }

    [JsonPropertyName("quality")]
    public string Quality { get; set; }

    [JsonPropertyName("filesize")]
    public int Filesize { get; set; }

    [JsonPropertyName("duration")]
    public int Duration { get; set; }
}