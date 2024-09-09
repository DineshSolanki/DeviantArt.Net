namespace DeviantArt.Net.Models.Deviation;

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

public class LicenseOption
{
    public bool CreativeCommons { get; set; }
    public bool Commercial { get; set; }
    public LicenseOptionsModify Modify { get; set; }
}