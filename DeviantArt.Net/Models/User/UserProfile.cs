namespace DeviantArt.Net.Models.User;

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class DetailedUserProfile : UserProfile
{
    [JsonPropertyName("user")]
    public User User { get; set; }

    [JsonPropertyName("is_watching")]
    public bool IsWatching { get; set; }

    [JsonPropertyName("profile_url")]
    public string ProfileUrl { get; set; }

    [JsonPropertyName("artist_specialty")]
    public string? ArtistSpecialty { get; set; }

    [JsonPropertyName("countryid")]
    public int CountryId { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("bio")]
    public string Bio { get; set; }

    [JsonPropertyName("cover_deviation")]
    public ApiModuleCoverDeviation? CoverDeviation { get; set; }

    [JsonPropertyName("last_status")]
    public Status? LastStatus { get; set; }

    [JsonPropertyName("stats")]
    public UserProfileStats UserProfileStats { get; set; }

    [JsonPropertyName("collections")]
    public List<Collection>? Collections { get; set; }

    [JsonPropertyName("galleries")]
    public List<Folder>? Galleries { get; set; }
}

public class ApiModuleCoverDeviation
{
    [JsonPropertyName("cover_deviation")]
    public Deviation.Deviation? CoverDeviation { get; set; }
    
    [JsonPropertyName("cover_deviationid_offset_y")]
    public int CoverDeviationIdOffsetY { get; set; }
    
    [JsonPropertyName("image_width")]
    public int? ImageWidth { get; set; }
    
    [JsonPropertyName("image_height")]
    public int? ImageHeight { get; set; }
    
    [JsonPropertyName("crop_x")]
    public int? CropX { get; set; }
    
    [JsonPropertyName("crop_y")]
    public int? CropY { get; set; }
    
    [JsonPropertyName("crop_width")]
    public int? CropWidth { get; set; }
    
    [JsonPropertyName("crop_height")]
    public int? CropHeight { get; set; }
}

public class UserProfileStats
{
    [JsonPropertyName("user_deviations")]
    public int UserDeviations { get; set; }

    [JsonPropertyName("user_favourites")]
    public int UserFavourites { get; set; }

    [JsonPropertyName("user_comments")]
    public int UserComments { get; set; }

    [JsonPropertyName("profile_pageviews")]
    public int ProfilePageviews { get; set; }

    [JsonPropertyName("profile_comments")]
    public int ProfileComments { get; set; }
}
