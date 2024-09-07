namespace DeviantArt.Net.Models.User;

public class WatchRequest
{
    [JsonPropertyName("watch[friend]")]
    public bool Friend { get; set; }

    [JsonPropertyName("watch[deviations]")]
    public bool Deviations { get; set; }

    [JsonPropertyName("watch[journals]")]
    public bool Journals { get; set; }

    [JsonPropertyName("watch[forum_threads]")]
    public bool ForumThreads { get; set; }

    [JsonPropertyName("watch[critiques]")]
    public bool Critiques { get; set; }

    [JsonPropertyName("watch[scraps]")]
    public bool Scraps { get; set; }

    [JsonPropertyName("watch[activity]")]
    public bool Activity { get; set; }

    [JsonPropertyName("watch[collections]")]
    public bool Collections { get; set; }
}