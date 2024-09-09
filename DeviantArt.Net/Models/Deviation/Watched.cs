namespace DeviantArt.Net.Models.Deviation;

public class Watched
{
    [JsonPropertyName("has_new_content")]
    public bool HasNewContent { get; set; }

    [JsonPropertyName("link_subnav")]
    public LinkSubnav LinkSubnav { get; set; }

    [JsonPropertyName("is_pinned")]
    public bool IsPinned { get; set; }
}