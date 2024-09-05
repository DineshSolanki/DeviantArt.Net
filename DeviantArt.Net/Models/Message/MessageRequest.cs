namespace DeviantArt.Net.Models.Message;

public class MessageRequest
{
    [JsonPropertyName("folderid")]
    public string? FolderId { get; set; }
    
    [JsonPropertyName("messageid")]
    public string? MessageId { get; set; }
    
    [JsonPropertyName("stackid")]
    public string? StackId { get; set; }
}