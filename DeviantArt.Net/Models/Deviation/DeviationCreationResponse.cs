namespace DeviantArt.Net.Models.Deviation;

internal class DeviationCreationResponse
{
    [JsonPropertyName("deviationid")]
    public Guid DeviationId { get; set; }
}