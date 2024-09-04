namespace DeviantArt.Net.Models;

public class BrowseResponse : PaginatedBase<Deviation>
{
    [JsonPropertyName("session")]
    public ApiSession Session { get; set; }
}