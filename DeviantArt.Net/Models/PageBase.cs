namespace DeviantArt.Net.Models;

public class PageBase
{
    [JsonPropertyName("has_more")]
    public bool HasMore { get; set; }

    [JsonPropertyName("has_less")]
    public bool HasLess { get; set; }
    
    [JsonPropertyName("next_offset")]
    public int? NextOffset { get; set; }

    [JsonPropertyName("next_cursor")]
    public string NextCursor { get; set; }

    [JsonPropertyName("prev_cursor")]
    public string PrevCursor { get; set; }
    
    
}