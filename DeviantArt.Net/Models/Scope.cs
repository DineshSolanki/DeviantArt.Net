﻿namespace DeviantArt.Net.Models;

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
    
    /*UserManage,
    Feed,
    Collection,
    CommentPost,
    Note,*/
}