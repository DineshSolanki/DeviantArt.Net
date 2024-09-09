namespace DeviantArt.Net.Models.Deviation;

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