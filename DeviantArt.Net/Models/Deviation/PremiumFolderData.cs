namespace DeviantArt.Net.Models.Deviation;

public class PremiumFolderData
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("has_access")]
    public bool HasAccess { get; set; }

    [JsonPropertyName("gallery_id")]
    public string GalleryId { get; set; }

    [JsonPropertyName("points_price")]
    public int? PointsPrice { get; set; }

    [JsonPropertyName("dollar_price")]
    public float? DollarPrice { get; set; }

    [JsonPropertyName("num_subscribers")]
    public int? NumSubscribers { get; set; }

    [JsonPropertyName("subproductid")]
    public int? SubproductId { get; set; }
}