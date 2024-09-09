using DeviantArt.Net.Models.Deviation;
using DeviantArt.Net.Modules;

namespace DeviantArt.Net.Models.Deviation;

public class journalCreationRequest
{

	/// <summary>
	/// Journal title
	/// </summary>
	[JsonPropertyName("title")]
	public string Title { get; set; }

	/// <summary>
	/// The body of the journal
	/// </summary>
	[JsonPropertyName("body")]
	public string? Body { get; set; }

	/// <summary>
	/// Journal tags
	/// </summary>
	[JsonPropertyName("tags")]
	public List<string>? Tags { get; set; }

	/// <summary>
	/// Cover deviation id
	/// </summary>
	[JsonPropertyName("cover_image_deviation_id")]
	public Guid? CoverImageDeviationId { get; set; }

	/// <summary>
	/// ID of the embedded deviation
	/// </summary>
	[JsonPropertyName("embedded_image_deviation_id")]
	public Guid? EmbeddedDeviationId { get; set; }

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
	
	[JsonIgnore]
	public LicenseOption LicenseOptions {get; set; }
	
}