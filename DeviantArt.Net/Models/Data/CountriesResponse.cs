namespace DeviantArt.Net.Models.Data;

public class CountriesResponse
{
    [JsonPropertyName("results")]
    public List<Country> Results { get; set; }
}