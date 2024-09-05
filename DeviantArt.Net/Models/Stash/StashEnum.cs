namespace DeviantArt.Net.Models.Stash;

public enum MatureLevel
{
    [Description("null")]
    [EnumMember(Value = null)]
    None = 0,
    
    [Description("strict")]
    [EnumMember(Value = "strict")]
    Strict,
    
    [Description("moderate")]
    [EnumMember(Value = "moderate")]
    Moderate
}

public enum MatureClassification
{
    [Description("null")]
    [EnumMember(Value = null)]
    None = 0,
    
    [Description("nudity")]
    [EnumMember(Value = "nudity")]
    Nudity,
    
    [Description("sexual")]
    [EnumMember(Value = "sexual")]
    Sexual,
    
    [Description("gore")]
    [EnumMember(Value = "gore")]
    Gore,
    
    [Description("language")]
    [EnumMember(Value = "language")]
    Language,
    
    [Description("ideology")]
    [EnumMember(Value = "ideology")]
    Ideology
}

public enum SharingOptions
{
    [Description("allow")]
    [EnumMember(Value = "allow")]
    Allow,
    
    [Description("hide_share_buttons")]
    [EnumMember(Value = "hide_share_buttons")]
    HideShareButtons,
    
    [Description("hinde_and_members_only")]
    [EnumMember(Value = "hide_and_members_only")]
    HideAndMembersOnly
}

public enum DisplayResolution
{
    Original = 0,
    Px400 = 1,
    Px600 = 2,
    Px800 = 3,
    Px900 = 4,
    Px1024 = 5,
    Px1280 = 6,
    Px1600 = 7,
    Px1920 = 8
}

public enum LicenseOptionsModify
{
    [Description("yes")]
    [EnumMember(Value = "yes")]
    Yes,
    
    [Description("no")]
    [EnumMember(Value = "no")]
    No,
    
    [Description("share")]
    [EnumMember(Value = "share")]
    Share
}