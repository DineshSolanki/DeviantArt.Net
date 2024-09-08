using DeviantArt.Net.Models.Message;

namespace DeviantArt.Net.Models;

public class CommentsPage : PageBase
{
    [JsonPropertyName("thread")]
    public List<Comment> Thread { get; set; }
    
    [JsonPropertyName("context")]
    public List<Context> Context { get; set; }
    
    [JsonPropertyName("total")]
    public int? Total { get; set; }
}

public class Context
{
    [JsonPropertyName("parent")]
    public Comment?Parent { get; set; }
    
    [JsonPropertyName("item_profile")]
    public User.User? ItemProfile { get; set; }
    
    [JsonPropertyName("item_deviation")]
    public Deviation? ItemDeviation { get; set; }
    
    [JsonPropertyName("item_status")]
    public Status? ItemStatus { get; set; }
}