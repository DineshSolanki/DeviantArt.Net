namespace DeviantArt.Net.Models.User;

public class PostStatusRequest
{
    /// <summary>
    /// The body of the status 
    /// </summary>
    [JsonPropertyName("body")]
    public string? Body { get; set; }

    /// <summary>
    /// The id of the object you wish to share 
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The parent id of the object you wish to share 
    /// </summary>
    [JsonPropertyName("parentid")]
    public string? ParentId { get; set; }

    /// <summary>
    /// The stash id of the object you wish to add to the status 
    /// </summary>
    [JsonPropertyName("stashid")]
    public string? StashId { get; set; }
}