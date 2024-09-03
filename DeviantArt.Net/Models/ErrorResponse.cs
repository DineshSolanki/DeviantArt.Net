using System.Text.Json.Serialization;

namespace DeviantArt.Net.Models;

public class ErrorResponse
{
    [JsonPropertyName("error")]
    public string ErrorType { get; set; }

    [JsonPropertyName("error_description")]
    public string ErrorDescription { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }
}