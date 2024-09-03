namespace DeviantArt.Net.Models;

public class BrowseTagsResponse
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

    [JsonPropertyName("error_code")]
    public int? ErrorCode { get; set; }

    [JsonPropertyName("results")]
    public List<Deviation> Results { get; set; }

    [JsonPropertyName("session")]
    public ApiSession Session { get; set; }
}