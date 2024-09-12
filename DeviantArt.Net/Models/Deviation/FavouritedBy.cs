namespace DeviantArt.Net.Models.Deviation;

public class FavouritedBy
{
    [JsonPropertyName("user")]
    public User.User User { get; set; }
    
    [JsonConverter(typeof(UnixTimestampConverter))]
    [JsonPropertyName("time")]
    public DateTimeOffset Time { get; set; }
}