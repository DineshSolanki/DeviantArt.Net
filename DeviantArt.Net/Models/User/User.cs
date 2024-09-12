namespace DeviantArt.Net.Models.User;

public class User
{
    [JsonPropertyName("userid")]
    public string UserId { get; set; }

    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("usericon")]
    public string UserIcon { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("is_watching")]
    public bool? IsWatching { get; set; }

    [JsonPropertyName("is_subscribed")]
    public bool? IsSubscribed { get; set; }

    [JsonPropertyName("details")]
    public UserDetails Details { get; set; }

    [JsonPropertyName("geo")]
    public UserGeo Geo { get; set; }

    [JsonPropertyName("profile")]
    public UserProfile Profile { get; set; }

    [JsonPropertyName("stats")]
    public UserStats Stats { get; set; }

    [JsonPropertyName("sidebar")]
    public UserSidebar Sidebar { get; set; }
}

public class UserDetails
{
    [JsonPropertyName("sex")]
    public string Sex { get; set; }

    [JsonPropertyName("age")]
    public int? Age { get; set; }

    [JsonPropertyName("joindate")]
    public string JoinDate { get; set; }
}

public class UserGeo
{
    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("countryid")]
    public int CountryId { get; set; }

    [JsonPropertyName("timezone")]
    public string Timezone { get; set; }
}

public class UserProfile
{
    [JsonPropertyName("user_is_artist")]
    public bool UserIsArtist { get; set; }

    [JsonPropertyName("artist_level")]
    public string ArtistLevel { get; set; }

    [JsonPropertyName("artist_speciality")]
    public string ArtistSpeciality { get; set; }

    [JsonPropertyName("real_name")]
    public string RealName { get; set; }

    [JsonPropertyName("tagline")]
    public string Tagline { get; set; }

    [JsonPropertyName("website")]
    public string Website { get; set; }

    [JsonPropertyName("cover_photo")]
    public string CoverPhoto { get; set; }
}

public class UserStats
{
    [JsonPropertyName("watchers")]
    public int Watchers { get; set; }

    [JsonPropertyName("friends")]
    public int Friends { get; set; }
}

public class UserSidebar
{
    [JsonPropertyName("watched")]
    public Watched Watched { get; set; }
}

public class WithSession
{
    [JsonPropertyName("session")]
    public ApiSession Session { get; set; }
}