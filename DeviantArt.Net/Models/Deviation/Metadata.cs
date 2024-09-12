namespace DeviantArt.Net.Models.Deviation;

public class Metadata
{
    [JsonPropertyName("deviationid")]
    public Guid DeviationId { get; set; }

    [JsonPropertyName("printid")]
    public Guid? PrintId { get; set; }

    [JsonPropertyName("author")]
    public User.User Author { get; set; }

    [JsonPropertyName("is_watching")]
    public bool IsWatching { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("license")]
    public string License { get; set; }

    [JsonPropertyName("allows_comments")]
    public bool AllowsComments { get; set; }

    [JsonPropertyName("tags")]
    public List<Tag> Tags { get; set; }

    [JsonPropertyName("is_favourited")]
    public bool IsFavourited { get; set; }

    [JsonPropertyName("is_mature")]
    public bool IsMature { get; set; }

    [JsonPropertyName("mature_level")]
    public MatureLevel? MatureLevel { get; set; }

    [JsonPropertyName("mature_classification")]
    public List<MatureClassification>? MatureClassification { get; set; }

    [JsonPropertyName("submission")]
    public Submission? Submission { get; set; }

    [JsonPropertyName("stats")]
    public DeviationStats? Stats { get; set; }

    [JsonPropertyName("camera")]
    public Dictionary<string, string>? Camera { get; set; }

    [JsonPropertyName("collections")]
    public List<Folder>? Collections { get; set; }

    [JsonPropertyName("galleries")]
    public List<Folder>? Galleries { get; set; }

    [JsonPropertyName("can_post_comment")]
    public bool CanPostComment { get; set; }
}

public class DeviationMetadataResponse : WithSession
{
    [JsonPropertyName("metadata")]
    public List<Metadata> Metadatas { get; set; }
}

public class DeviationMetadataRequest
{
    /// <summary>
    ///  The deviation ids you want metadata for 
    /// </summary>
    [JsonPropertyName("deviationids")]
    public List<Guid> DeviationIds { get; set; }
    
    /// <summary>
    /// Return extended information - submission information 
    /// </summary>
    [JsonPropertyName("ext_submission")]
    public bool? ExtSubmission { get; set; }
    
    /// <summary>
    /// Return extended information - EXIF information (if available) 
    /// </summary>
    [JsonPropertyName("ext_camera")]
    public bool? ExtCamera { get; set; }
    
    /// <summary>
    ///  Return extended information - deviation statistics
    /// </summary>
    [JsonPropertyName("ext_stats")]
    public bool? ExtStats { get; set; }
    
    /// <summary>
    /// Return extended information - favourite folder information (only available for logged-in sessions)
    /// </summary>
    [JsonPropertyName("ext_collection")]
    public bool? ExtCollection { get; set; }
    
    /// <summary>
    /// Return extended information - gallery folder information (only available for logged in sessions)
    /// </summary>
    [JsonPropertyName("ext_galleries")]
    public bool? ExtGalleries { get; set; }
}
public class Submission
{
    [JsonPropertyName("creation_time")]
    public DateTime CreationTime { get; set; }

    [JsonPropertyName("category")]
    public string Category { get; set; }

    [JsonPropertyName("file_size")]
    public string? FileSize { get; set; }

    [JsonPropertyName("resolution")]
    public string? Resolution { get; set; }

    [JsonPropertyName("submitted_with")]
    public SubmittedWith? SubmittedWith { get; set; }
}

public class SubmittedWith
{
    [JsonPropertyName("app")]
    public string App { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}