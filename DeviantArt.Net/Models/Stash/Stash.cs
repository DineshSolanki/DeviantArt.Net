using DeviantArt.Net.Modules.Util.converter;

namespace DeviantArt.Net.Models.Stash;

[DataContract]
public class PublishStashRequest
{
    [JsonPropertyName("itemid")] [AliasAs("itemid")]
    public int ItemId { get; set; }

    [JsonPropertyName("is_mature")] [AliasAs("is_mature")]
    public bool IsMature { get; set; }

    [JsonPropertyName("mature_level")] [AliasAs("mature_level")]
    public MatureLevel? MatureLevel { get; set; }

    [JsonPropertyName("mature_classification")] [AliasAs("mature_classification")]
    public MatureClassification[] MatureClassification { get; set; }

    [JsonPropertyName("feature")] [AliasAs("feature")]
    public bool Feature { get; set; } = true;

    [JsonPropertyName("allow_comments")] [AliasAs("allow_comments")]
    public bool AllowComments { get; set; } = true;

    [JsonPropertyName("request_critique")] [AliasAs("request_critique")]
    public bool RequestCritique { get; set; }

    [JsonPropertyName("display_resolution")] [AliasAs("display_resolution")]
    public DisplayResolution? DisplayResolution { get; set; }

    [JsonPropertyName("sharing")] [AliasAs("sharing")]
    public SharingOptions? Sharing { get; set; } = SharingOptions.Allow;

    [JsonPropertyName("license_options")] [AliasAs("license_options")]
    public Dictionary<string, bool> LicenseOptions { get; set; }

    [JsonPropertyName("galleryids")] [AliasAs("galleryids")]
    [Query(CollectionFormat.Csv)]
    public Guid[] GalleryIds { get; set; }

    [JsonPropertyName("allow_free_download")] [AliasAs("allow_free_download")]
    public bool AllowFreeDownload { get; set; }

    [JsonPropertyName("add_watermark")] [AliasAs("add_watermark")]
    public bool AddWatermark { get; set; }

    [JsonPropertyName("is_ai_generated")] [AliasAs("is_ai_generated")]
    public bool IsAiGenerated { get; set; }

    [JsonPropertyName("catpath")] [AliasAs("catpath")]
    public string CatPath { get; set; }
}

public class PublishStashResponse
{
    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("deviationid")]
    public Guid DeviationId { get; set; }
}
