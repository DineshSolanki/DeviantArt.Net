﻿namespace DeviantArt.Net.Models;

public class SeededResponse
{
    
    [JsonPropertyName("seed")]
    public Guid Seed { get; set; }

    [JsonPropertyName("author")]
    public User.User Author { get; set; }

    [JsonPropertyName("more_from_artist")]
    public List<Deviation.Deviation> MoreFromArtist { get; set; }

    [JsonPropertyName("more_from_da")]
    public List<Deviation.Deviation> MoreFromDa { get; set; }

    [JsonPropertyName("suggested_collections")]
    public List<SuggestedCollection>? SuggestedCollections { get; set; }
}

public class SuggestedCollection
{
    [JsonPropertyName("collection")]
    public Collection Collection { get; set; }

    [JsonPropertyName("deviations")]
    public List<Deviation.Deviation> Deviations { get; set; }
}

public class Collection
{
    [JsonPropertyName("folderid")]
    public int FolderId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("owner")]
    public User.User Owner { get; set; }
}