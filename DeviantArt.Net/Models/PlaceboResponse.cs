using System.Text.Json.Serialization;

namespace DeviantArt.Net.Models;

public class PlaceboResponse
{
    [JsonPropertyName("status")]
    public string Status { get; set; }
}