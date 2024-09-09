namespace DeviantArt.Net.Models.Deviation;

public class DeviationContent
{
    [JsonPropertyName("html")]
    public string? Html { get; set; }
    
    [JsonPropertyName("css")]
    public string? Css { get; set; }
    
    [JsonPropertyName("css_fonts")]
    public List<string>? CssFonts { get; set; }
    
    [JsonPropertyName("session")]
    public ApiSession? Session { get; set; }
}