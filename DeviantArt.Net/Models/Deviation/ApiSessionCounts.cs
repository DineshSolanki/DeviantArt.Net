namespace DeviantArt.Net.Models.Deviation;

public class ApiSessionCounts
{
    [JsonPropertyName("feedback")]
    public int Feedback { get; set; }

    [JsonPropertyName("notes")]
    public int Notes { get; set; }
}