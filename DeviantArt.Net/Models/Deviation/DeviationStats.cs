namespace DeviantArt.Net.Models.Deviation;

public class DeviationStats
{
    [JsonPropertyName("views")]
    public int Views { get; set; }

    [JsonPropertyName("views_today")]
    public int? ViewsToday { get; set; }

    [JsonPropertyName("favourites")]
    public int Favourites { get; set; }

    [JsonPropertyName("comments")]
    public int Comments { get; set; }

    [JsonPropertyName("downloads")]
    public int Downloads { get; set; }

    [JsonPropertyName("downloads_today")]
    public int? DownloadsToday { get; set; }
}