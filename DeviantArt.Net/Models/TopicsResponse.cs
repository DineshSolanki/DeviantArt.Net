namespace DeviantArt.Net.Models;

public class TopicsResponse : PaginatedBase<TopicResult>
{
    [JsonPropertyName("session")]
    public ApiSession? Session { get; set; }
}

public class TopicResult
{
     [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("canonical_name")]
    public string CanonicalName { get; set; }
    
    [JsonPropertyName("example_deviations")]
    public List<Deviation>? ExampleDeviations { get; set; }
    
    [JsonPropertyName("deviations")]
    public List<Deviation?> Deviations { get; set; }
}