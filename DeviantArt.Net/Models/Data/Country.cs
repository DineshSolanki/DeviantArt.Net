namespace DeviantArt.Net.Models.Data;

public class Country
{
    [JsonPropertyName("countryid")]
    public int CountryId { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
}