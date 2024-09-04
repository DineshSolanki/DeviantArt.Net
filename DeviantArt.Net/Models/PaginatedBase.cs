namespace DeviantArt.Net.Models;

public class PaginatedBase<T>
{
    [JsonPropertyName("has_more")]
    public bool HasMore { get; set; }

    [JsonPropertyName("next_offset")]
    public int? NextOffset { get; set; }

    [JsonPropertyName("next_cursor")]
    public string NextCursor { get; set; }

    [JsonPropertyName("prev_cursor")]
    public string PrevCursor { get; set; }

    [JsonPropertyName("estimated_total")]
    public int? EstimatedTotal { get; set; }
    
    [JsonPropertyName("results")]
    public List<T> Results { get; set; }
}