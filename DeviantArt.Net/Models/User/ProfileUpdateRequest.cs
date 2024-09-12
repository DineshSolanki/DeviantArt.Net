namespace DeviantArt.Net.Models.User;

public class ProfileUpdateRequest
{

    /// <summary>
    /// Is the user an artist?
    /// </summary>
    [JsonPropertyName("user_is_artist")]
    public bool? UserIsArtist { get; set; }

    /// <summary>
    /// If the user is an artist, what level are they?
    /// </summary>
    [JsonPropertyName("artist_level")]
    public ArtistLevel? ArtistLevel { get; set; }

    /// <summary>
    /// If the user is an artist, what is their specialty
    /// </summary>
    [JsonPropertyName("artist_specialty")]
    public ArtistSpecialty? ArtistSpecialty { get; set; }
    
    /// <summary>
    /// The user's location
    /// </summary>
    public Country Country { get; set; }

    /// <summary>
    /// User's website
    /// </summary>
    [JsonPropertyName("website")]
    public string? Website { get; set; }
    
    [JsonPropertyName("website_label")]
    public string? WebsiteLabel { get; set; }
    
    [JsonPropertyName("tagline")]
    public string? TagLine { get; set; }

    [JsonPropertyName("show_badges")]
    public bool? ShowBadges { get; set; }
    
    [JsonPropertyName("interests")]
    [Query(CollectionFormat.Multi)]
    public List<Interest>? Interests { get; set; }
    
    [JsonPropertyName("social_links")]
    public List<SocialLink>? SocialLinks { get; set; }
    
}

public class Interest
{
    public InterestType Type { get; set; }
    public string Value { get; set; }
}

public class SocialLink
{
    public SocialLinkType Type { get; set; }
    public string Url { get; set; }
}

public enum ArtistLevel
{
    [EnumMember(Value = "0")]
    None = 0,
    
    [EnumMember(Value = "1")]
    Student = 1,
    
    [EnumMember(Value = "2")]
    Hobbyist = 2,
    
    [EnumMember(Value = "3")]
    Professional = 3
}

public enum ArtistSpecialty
{
    [EnumMember(Value = "0")]
    None = 0,
    
    [EnumMember(Value = "1")]
    ArisanCrafts = 1,
    
    [EnumMember(Value = "2")]
    DesignAndInterfaces = 2,
    
    [EnumMember(Value = "3")]
    DigitalArt = 3,
    
    [EnumMember(Value = "4")]
    FilmAndAnimation = 4,
    
    [EnumMember(Value = "5")]
    Literature = 5,
    
    [EnumMember(Value = "6")]
    Photography = 6,
    
    [EnumMember(Value = "7")]
    TraditionalArt = 7,
    
    [EnumMember(Value = "8")]
    Other = 8,
    
    [EnumMember(Value = "9")]
    Varied = 9
}

public enum InterestType
{
    [EnumMember(Value = "1")]
    FavoriteVisualArtist,
    [EnumMember(Value = "2")]
    FavoriteMovies,
    [EnumMember(Value = "3")]
    FavoriteTvShows,
    [EnumMember(Value = "4")]
    FavoriteBandsOrMusicalArtists,
    [EnumMember(Value = "5")]
    FavoriteBooks,
    [EnumMember(Value = "6")]
    FavoriteWriters,
    [EnumMember(Value = "7")]
    FavoriteGames,
    [EnumMember(Value = "8")]
    FavoriteGamingPlatform,
    [EnumMember(Value = "9")]
    ToolsOfTheTrade,
    [EnumMember(Value = "10")]
    OtherInterests
}

public enum SocialLinkType
{
    [EnumMember(Value = "1")]
    Behance,
    [EnumMember(Value = "2")]
    Dribbble,
    [EnumMember(Value = "3")]
    Etsy,
    [EnumMember(Value = "4")]
    Facebook,
    [EnumMember(Value = "5")]
    Flickr,
    [EnumMember(Value = "6")]
    GooglePlus,
    [EnumMember(Value = "7")]
    Instagram,
    [EnumMember(Value = "8")]
    LinkedIn,
    [EnumMember(Value = "9")]
    Patreon,
    [EnumMember(Value = "10")]
    Pinterest,
    [EnumMember(Value = "11")]
    Tumblr,
    [EnumMember(Value = "12")]
    Twitch,
    [EnumMember(Value = "13")]
    Twitter,
    [EnumMember(Value = "14")]
    Vimeo,
    [EnumMember(Value = "15")]
    YouTube
}
