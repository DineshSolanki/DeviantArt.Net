using DeviantArt.Net.Modules.Util.Formatters;

namespace DeviantArt.Net.Models.User;

public class Friend : Watcher
{
    [JsonPropertyName("watches_you")] public bool WatchesYou { get; set; }

}

public class Watcher
{
    /// <summary>
    /// Watcher
    /// </summary>
    [JsonPropertyName("user")] public User User { get; set; }

    /// <summary>
    /// Whether authenticated user watches this watcher
    /// </summary>
    [JsonPropertyName("is_watching")] public bool IsWatching { get; set; }
    
    /// <summary>
    /// Last visit time
    /// </summary>
    [JsonPropertyName("lastvisit")] [JsonConverter(typeof(DateTimeNullableConverter))]
    public DateTime? LastVisit { get; set; }

    /// <summary>
    /// Object describing what items are being watched
    /// </summary>
    [JsonPropertyName("watch")] public Watch Watch { get; set; }
}
public class Watch
{
    [JsonPropertyName("friend")] public bool Friend { get; set; }

    [JsonPropertyName("deviations")] public bool Deviations { get; set; }

    [JsonPropertyName("journals")] public bool Journals { get; set; }

    [JsonPropertyName("forum_threads")] public bool ForumThreads { get; set; }

    [JsonPropertyName("critiques")] public bool Critiques { get; set; }

    [JsonPropertyName("scraps")] public bool Scraps { get; set; }

    [JsonPropertyName("activity")] public bool Activity { get; set; }

    [JsonPropertyName("collections")] public bool Collections { get; set; }
}
