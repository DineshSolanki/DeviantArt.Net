namespace DeviantArt.Net.Models.Deviation;

public enum TierAccess
{
    [EnumMember(Value = "locked")]
    Locked,
    
    [EnumMember(Value = "unlocked")]
    Unlocked,
    
    [EnumMember(Value = "locked-subscribed")]
    LockedSubscribed
}