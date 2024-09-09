namespace DeviantArt.Net.Models.Deviation;

public class ApiSession
{
    [JsonPropertyName("user")]
    public ApiSessionUser User { get; set; }

    [JsonPropertyName("counts")]
    public ApiSessionCounts Counts { get; set; }
}