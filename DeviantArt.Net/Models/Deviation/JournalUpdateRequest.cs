namespace DeviantArt.Net.Models.Deviation;

public class JournalUpdateRequest: UpdateRequest
{
	
    /// <summary>
    /// Cover deviation id
    /// </summary>
    [JsonPropertyName("cover_image_deviation_id")]
    public Guid? CoverImageDeviationId { get; set; }

    /// <summary>
    /// ID of the embedded deviation
    /// </summary>
    [JsonPropertyName("reset_cover_image_deviation_id")]
    public bool? ResetCoverImage { get; set; }
    
}

public class DeviationUpdateRequest : UpdateRequest
{
	[JsonPropertyName("mature_level")]
	public MatureLevel? MatureLevel { get; set; }
	
	[JsonPropertyName("mature_classification")]
	public List<MatureClassification>? MatureClassification { get; set; }
	
	[JsonPropertyName("galleryids")]
	public List<Guid>? GalleryIds { get; set; }
	
	[JsonPropertyName("allow_free_download")]
	public bool? AllowFreeDownload { get; set; }
	
	[JsonPropertyName("add_watermark")]
	public bool? AddWatermark { get; set; }
}
public class UpdateRequest
{
	
	/// <summary>
	/// The deviation id you want to update 
	/// </summary>
	[JsonPropertyName("deviationid")]
	public Guid DeviationId { get; set; }
	
	/// <summary>
	/// Deviation title
	/// </summary>
	[JsonPropertyName("title")]
	public string Title { get; set; }
	
	/// <summary>
	/// Submission is mature or not
	/// </summary>
	[JsonPropertyName("is_mature")]
	public bool IsMature { get; set; }
	
	/// <summary>
	/// Allow comments?
	/// </summary>
	[JsonPropertyName("allow_comments")]
	public bool? AllowComments { get; set; }
	
	/// <summary>
	/// Deviation tags
	/// </summary>
	[JsonPropertyName("tags")]
	public List<string>? Tags { get; set; }
	
	[JsonIgnore]
	public LicenseOption LicenseOptions {get; set; }
	
}

public class LiteratureCreationRequest
{
	/// <summary>
	/// Deviation title
	/// </summary>
	[JsonPropertyName("title")]
	public string Title { get; set; }
	
	/// <summary>
	/// The body of the literature
	/// </summary>
	[JsonPropertyName("body")]
	public string? Body { get; set; }
	
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// Literature tags
	/// </summary>
	[JsonPropertyName("tags")]
	public List<string>? Tags { get; set; }
	
	[JsonPropertyName("galleryids")]
	public List<Guid>? GalleryIds { get; set; }
	
	/// <summary>
	/// Submission is mature or not
	/// </summary>
	[JsonPropertyName("is_mature")]
	public bool IsMature { get; set; }
	
	[JsonPropertyName("mature_level")]
	public MatureLevel? MatureLevel { get; set; }
	
	[JsonPropertyName("mature_classification")]
	public List<MatureClassification>? MatureClassification { get; set; }
	
	/// <summary>
	/// Allow comments?
	/// </summary>
	[JsonPropertyName("allow_comments")]
	public bool? AllowComments { get; set; }
	
	[JsonIgnore]
	public LicenseOption LicenseOptions {get; set; }
	
	/// <summary>
	/// ID of the embedded deviation
	/// </summary>
	[JsonPropertyName("embedded_image_deviation_id")]
	public Guid? EmbeddedDeviationId { get; set; }
}

public class LiteratureUpdateRequest
{
	
	/// <summary>
	/// The deviation id you want to update 
	/// </summary>
	[JsonPropertyName("deviationid")]
	public Guid DeviationId { get; set; }
	
	/// <summary>
	/// Deviation title
	/// </summary>
	[JsonPropertyName("title")]
	public string Title { get; set; }

	/// <summary>
	/// Literature tags
	/// </summary>
	[JsonPropertyName("tags")]
	public List<string>? Tags { get; set; }
	
	[JsonPropertyName("galleryids")]
	public List<Guid>? GalleryIds { get; set; }
	
	/// <summary>
	/// Submission is mature or not
	/// </summary>
	[JsonPropertyName("is_mature")]
	public bool IsMature { get; set; }
	
	[JsonPropertyName("mature_level")]
	public MatureLevel? MatureLevel { get; set; }
	
	[JsonPropertyName("mature_classification")]
	public List<MatureClassification>? MatureClassification { get; set; }
	
	/// <summary>
	/// Allow comments?
	/// </summary>
	[JsonPropertyName("allow_comments")]
	public bool? AllowComments { get; set; }
	
	[JsonIgnore]
	public LicenseOption LicenseOptions {get; set; }
	
}
public enum MatureLevel
{
	[Description("null")]
	[EnumMember(Value = null)]
	None = 0,
    
	[Description("strict")]
	[EnumMember(Value = "strict")]
	Strict,
    
	[Description("moderate")]
	[EnumMember(Value = "moderate")]
	Moderate
}

public enum MatureClassification
{
	[Description("null")]
	[EnumMember(Value = null)]
	None = 0,
    
	[Description("nudity")]
	[EnumMember(Value = "nudity")]
	Nudity,
    
	[Description("sexual")]
	[EnumMember(Value = "sexual")]
	Sexual,
    
	[Description("gore")]
	[EnumMember(Value = "gore")]
	Gore,
    
	[Description("language")]
	[EnumMember(Value = "language")]
	Language,
    
	[Description("ideology")]
	[EnumMember(Value = "ideology")]
	Ideology
}