namespace DeviantArt.Net.Models.Deviation;

public class Deviation
{
    [JsonPropertyName("deviationid")]
    public Guid DeviationId { get; set; }

    [JsonPropertyName("printid")]
    public string PrintId { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("is_favourited")]
    public bool IsFavourited { get; set; }

    [JsonPropertyName("is_deleted")]
    public bool IsDeleted { get; set; }

    [JsonPropertyName("is_published")]
    public bool IsPublished { get; set; }

    [JsonPropertyName("is_blocked")]
    public bool IsBlocked { get; set; }

    [JsonPropertyName("author")]
    public User.User Author { get; set; }

    [JsonPropertyName("stats")]
    public DeviationStats DeviationStats { get; set; }

    [JsonPropertyName("published_time")]
    public string PublishedTime { get; set; }

    [JsonPropertyName("allows_comments")]
    public bool AllowsComments { get; set; }

    [JsonPropertyName("tier")]
    public DeviationTier Tier { get; set; }

    [JsonPropertyName("preview")]
    public Preview Preview { get; set; }

    [JsonPropertyName("content")]
    public Content Content { get; set; }

    [JsonPropertyName("thumbs")]
    public List<Thumbnail> Thumbs { get; set; }

    [JsonPropertyName("videos")]
    public List<Video> Videos { get; set; }

    [JsonPropertyName("flash")]
    public Flash Flash { get; set; }

    [JsonPropertyName("daily_deviation")]
    public DailyDeviation DailyDeviation { get; set; }

    [JsonPropertyName("premium_folder_data")]
    public PremiumFolderData PremiumFolderData { get; set; }

    [JsonPropertyName("text_content")]
    public EditorText TextContent { get; set; }

    [JsonPropertyName("is_pinned")]
    public bool IsPinned { get; set; }

    [JsonPropertyName("cover_image")]
    public Deviation CoverImage { get; set; }

    [JsonPropertyName("tier_access")]
    public TierAccess TierAccess { get; set; }

    [JsonPropertyName("primary_tier")]
    public Deviation PrimaryTier { get; set; }

    [JsonPropertyName("excerpt")]
    public string Excerpt { get; set; }

    [JsonPropertyName("is_mature")]
    public bool IsMature { get; set; }

    [JsonPropertyName("is_downloadable")]
    public bool IsDownloadable { get; set; }

    [JsonPropertyName("download_filesize")]
    public int DownloadFilesize { get; set; }

    [JsonPropertyName("motion_book")]
    public MotionBook MotionBook { get; set; }
}