namespace DeviantArt.Net.Models;

public class PaginatedBase<T> : PageBase
{
    [JsonPropertyName("estimated_total")]
    public int? EstimatedTotal { get; set; }
    
    [JsonPropertyName("results")]
    public List<T> Results { get; set; }
}