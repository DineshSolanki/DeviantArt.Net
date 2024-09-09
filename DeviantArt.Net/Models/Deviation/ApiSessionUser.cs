namespace DeviantArt.Net.Models.Deviation;

public class ApiSessionUser
{
    [JsonPropertyName("userid")]
    public string UserId { get; set; }

    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("usericon")]
    public string UserIcon { get; set; }

    [JsonPropertyName("symbol_class")]
    public string SymbolClass { get; set; }
}