namespace DeviantArt.Net.Models.User;

public class PostStatusResponse
{
    [JsonPropertyName("statusid")]
    public Guid StatusId { get; set; }
}