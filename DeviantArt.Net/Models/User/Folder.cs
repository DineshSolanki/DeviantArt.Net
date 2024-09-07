namespace DeviantArt.Net.Models.User;

public class Folder
{
    [JsonPropertyName("folderid")]
    public Guid FolderId { get; set; }

    [JsonPropertyName("parent")]
    public Guid? Parent { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}