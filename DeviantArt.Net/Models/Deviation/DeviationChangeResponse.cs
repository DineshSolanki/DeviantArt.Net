namespace DeviantArt.Net.Models.Deviation;

public class DeviationChangeResponse
{
    [JsonPropertyName("status")]
    public string Status { get; set; }
    
    [JsonPropertyName("url")]
    public string Url { get; set; }
    
    [JsonPropertyName("deviationid")]
    public Guid DeviationId { get; set; }
}