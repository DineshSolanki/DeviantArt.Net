namespace DeviantArt.Net.Models.Deviation;

public class TierStats
{
    [JsonPropertyName("subscribers")]
    public int? Subscribers { get; set; }

    [JsonPropertyName("deviations")]
    public int? Deviations { get; set; }

    [JsonPropertyName("posts")]
    public int? Posts { get; set; }

    [JsonPropertyName("total")]
    public int? Total { get; set; }
}