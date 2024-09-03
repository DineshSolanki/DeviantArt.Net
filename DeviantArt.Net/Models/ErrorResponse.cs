namespace DeviantArt.Net.Models;

public class ErrorResponse
{
    [JsonPropertyName("error")]
    public string ErrorType { get; set; }

    [JsonPropertyName("error_description")]
    public string ErrorDescription { get; set; }
    
    [JsonPropertyName("error_details")]
    public Dictionary<string, string>? ErrorDetails { get; set; }

    [JsonPropertyName("error_code")]
    public int? ErrorCode { get; set; } // Optional

    [JsonPropertyName("status")]
    public string Status { get; set; }
}