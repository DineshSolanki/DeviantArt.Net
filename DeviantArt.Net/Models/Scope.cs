namespace DeviantArt.Net.Models;

public enum Scope
{
    [Description("basic")] [EnumMember(Value = "basic")]
    Basic,
    
    [Description("browse")] [EnumMember(Value = "browse")]
    Browse,
    
    [Description("user")] [EnumMember(Value = "user")]
    User,
    
    [Description("stash")] [EnumMember(Value = "stash")]
    Stash,
    
    [Description("publish")] [EnumMember(Value = "publish")]
    Publish,
    
    [Description("message")] [EnumMember(Value = "message")]
    Message,
    
    [Description("user.manage")] [EnumMember(Value = "user.manage")]
    UserManage,
    
    [Description("comment.post")] [EnumMember(Value = "comment.post")]
    CommentPost,
    /*
    Feed,
    Collection,
    ,
    Note,*/
}