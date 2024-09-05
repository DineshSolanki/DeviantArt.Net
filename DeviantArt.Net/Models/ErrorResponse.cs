using System.Text;

namespace DeviantArt.Net.Models;

public class ErrorResponse
{
    [JsonPropertyName("error")]
    public string ErrorType { get; init; }

    [JsonPropertyName("error_description")]
    public string ErrorDescription { get; init; }
    
    [JsonPropertyName("error_details")]
    public Dictionary<string, string>? ErrorDetails { get; init; }

    [JsonPropertyName("error_code")]
    public int? ErrorCode { get; init; } // Optional

    [JsonPropertyName("status")]
    public string Status { get; init; }
    
    [JsonExtensionData]
    public Dictionary<string, object> AdditionalData { get; init; } = new();
    
    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine(
            $"ErrorType: {ErrorType}, ErrorDescription: {ErrorDescription}, Status: {Status}");
        if (ErrorDetails is not null )
        {
            sb.AppendLine("ErrorDetails:");
            foreach (var (key, value) in ErrorDetails)
            {
                sb.AppendLine($"{key}: {value}");
            }
        }

        if (ErrorCode.HasValue)
        {
            sb.AppendLine($"ErrorCode: {ErrorCode}");
        }
        if (AdditionalData.Count <= 0) return sb.ToString();
        sb.AppendLine("AdditionalData:");
        foreach (var (key, value) in AdditionalData)
        {
            sb.AppendLine($"{key}: {value.ToString()}");
        }
        
        return sb.ToString();
    }
}