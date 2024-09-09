namespace DeviantArt.Net.Models.Deviation;

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