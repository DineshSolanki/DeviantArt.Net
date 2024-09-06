namespace DeviantArt.Net.Models.Message;

public enum FeedbackMessageType
{
    [Description("comments")] [EnumMember(Value = "comments")]
    Comments, 
    
    [Description("replies")] [EnumMember(Value = "replies")]
    Replies, 
    
    [Description("activity")] [EnumMember(Value = "activity")]
    Activity
}