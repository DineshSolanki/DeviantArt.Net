namespace DeviantArt.Net.Models;

public class Deviation
{
    [JsonPropertyName("deviationid")]
    public string DeviationId { get; set; }

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
    public string TierAccess { get; set; }

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

public class Watched
{
    [JsonPropertyName("has_new_content")]
    public bool HasNewContent { get; set; }

    [JsonPropertyName("link_subnav")]
    public LinkSubnav LinkSubnav { get; set; }

    [JsonPropertyName("is_pinned")]
    public bool IsPinned { get; set; }
}

public class LinkSubnav
{
    [JsonPropertyName("content_type")]
    public string ContentType { get; set; }
}

public class ApiSession
{
    [JsonPropertyName("user")]
    public ApiSessionUser User { get; set; }

    [JsonPropertyName("counts")]
    public ApiSessionCounts Counts { get; set; }
}

public class ApiSessionUser
{
    [JsonPropertyName("userid")]
    public string UserId { get; set; }

    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("usericon")]
    public string UserIcon { get; set; }

    [JsonPropertyName("symbol_class")]
    public string SymbolClass { get; set; }
}

public class ApiSessionCounts
{
    [JsonPropertyName("feedback")]
    public int Feedback { get; set; }

    [JsonPropertyName("notes")]
    public int Notes { get; set; }
}

public class DeviationStats
{
    [JsonPropertyName("comments")]
    public int Comments { get; set; }

    [JsonPropertyName("favourites")]
    public int Favourites { get; set; }
}

public class DeviationTier
{
    [JsonPropertyName("state")]
    public string State { get; set; }

    [JsonPropertyName("is_user_subscribed")]
    public bool? IsUserSubscribed { get; set; }

    [JsonPropertyName("can_user_subscribe")]
    public bool? CanUserSubscribe { get; set; }

    [JsonPropertyName("subproductid")]
    public int? SubproductId { get; set; }

    [JsonPropertyName("dollar_price")]
    public string DollarPrice { get; set; }

    [JsonPropertyName("settings")]
    public TierSettings Settings { get; set; }

    [JsonPropertyName("stats")]
    public TierStats Stats { get; set; }

    [JsonPropertyName("benefits")]
    public List<string> Benefits { get; set; }
}

public class TierSettings
{
    [JsonPropertyName("access_settings")]
    public string AccessSettings { get; set; }
}

public class TierStats
{
    [JsonPropertyName("subscribers")]
    public int? Subscribers { get; set; }

    [JsonPropertyName("deviations")]
    public int? Deviations { get; set; }

    [JsonPropertyName("posts")]
    public int? Posts { get; set; }

    [JsonPropertyName("total")]
    public int? Total { get; set; }
}

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

public class EditorText
{
    [JsonPropertyName("excerpt")]
    public string Excerpt { get; set; }

    [JsonPropertyName("body")]
    public EditorTextBody Body { get; set; }
}

public class EditorTextBody
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("markup")]
    public string Markup { get; set; }

    [JsonPropertyName("features")]
    public string Features { get; set; }
}
public class Preview
{
    [JsonPropertyName("src")]
    public string Src { get; set; }

    [JsonPropertyName("height")]
    public int Height { get; set; }

    [JsonPropertyName("width")]
    public int Width { get; set; }

    [JsonPropertyName("transparency")]
    public bool Transparency { get; set; }
}

public class Content
{
    [JsonPropertyName("src")]
    public string Src { get; set; }

    [JsonPropertyName("height")]
    public int Height { get; set; }

    [JsonPropertyName("width")]
    public int Width { get; set; }

    [JsonPropertyName("transparency")]
    public bool Transparency { get; set; }

    [JsonPropertyName("filesize")]
    public int Filesize { get; set; }
}

public class Thumbnail
{
    [JsonPropertyName("src")]
    public string Src { get; set; }

    [JsonPropertyName("height")]
    public int Height { get; set; }

    [JsonPropertyName("width")]
    public int Width { get; set; }

    [JsonPropertyName("transparency")]
    public bool Transparency { get; set; }
}

public class Video
{
    [JsonPropertyName("src")]
    public string Src { get; set; }

    [JsonPropertyName("quality")]
    public string Quality { get; set; }

    [JsonPropertyName("filesize")]
    public int Filesize { get; set; }

    [JsonPropertyName("duration")]
    public int Duration { get; set; }
}

public class Flash
{
    [JsonPropertyName("src")]
    public string Src { get; set; }

    [JsonPropertyName("height")]
    public int Height { get; set; }

    [JsonPropertyName("width")]
    public int Width { get; set; }
}

public class DailyDeviation
{
    [JsonPropertyName("body")]
    public string Body { get; set; }

    [JsonPropertyName("time")]
    public string Time { get; set; }

    [JsonPropertyName("giver")]
    public User.User Giver { get; set; }

    [JsonPropertyName("suggester")]
    public User.User Suggester { get; set; }
}

public class MotionBook
{
    [JsonPropertyName("embed_url")]
    public string EmbedUrl { get; set; }
}