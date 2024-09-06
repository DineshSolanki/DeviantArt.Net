namespace DeviantArt.Net.Models.Message;

public class Message
{
    [JsonPropertyName("messageid")]
    public string MessageId { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("orphaned")]
    public bool Orphaned { get; set; }

    [JsonPropertyName("ts")]
    public string Ts { get; set; }

    [JsonPropertyName("stackid")]
    public string StackId { get; set; }

    [JsonPropertyName("stack_count")]
    public int? StackCount { get; set; }

    [JsonPropertyName("is_new")]
    public bool IsNew { get; set; }

    [JsonPropertyName("originator")]
    public User Originator { get; set; }

    [JsonPropertyName("subject")]
    public Subject Subject { get; set; }

    [JsonPropertyName("html")]
    public string Html { get; set; }

    [JsonPropertyName("profile")]
    public User Profile { get; set; }

    [JsonPropertyName("deviation")]
    public Deviation Deviation { get; set; }

    [JsonPropertyName("status")]
    public Status Status { get; set; }

    [JsonPropertyName("comment")]
    public Comment Comment { get; set; }

    [JsonPropertyName("collection")]
    public Collection Collection { get; set; }
}

public class Subject
{
    [JsonPropertyName("profile")]
    public User Profile { get; set; }

    [JsonPropertyName("deviation")]
    public Deviation Deviation { get; set; }

    [JsonPropertyName("status")]
    public Status Status { get; set; }

    [JsonPropertyName("comment")]
    public Comment Comment { get; set; }

    [JsonPropertyName("collection")]
    public Collection Collection { get; set; }

    [JsonPropertyName("gallery")]
    public Collection Gallery { get; set; }
}


public class Status
{
    [JsonPropertyName("statusid")]
    public Guid? StatusId { get; set; }

    [JsonPropertyName("body")]
    public string Body { get; set; }

    [JsonPropertyName("ts")]
    public string Ts { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("comments_count")]
    public int? CommentsCount { get; set; }

    [JsonPropertyName("is_share")]
    public bool? IsShare { get; set; }

    [JsonPropertyName("is_deleted")]
    public bool IsDeleted { get; set; }

    [JsonPropertyName("author")]
    public User Author { get; set; }

    [JsonPropertyName("items")]
    public List<Item> Items { get; set; }

    [JsonPropertyName("text_content")]
    public EditorText TextContent { get; set; }
}

public class Item
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("status")]
    public Status Status { get; set; }

    [JsonPropertyName("deviation")]
    public Deviation Deviation { get; set; }
}

public class Comment
{
    [JsonPropertyName("commentid")]
    public Guid CommentId { get; set; }

    [JsonPropertyName("parentid")]
    public Guid? ParentId { get; set; }

    [JsonPropertyName("posted")]
    public string Posted { get; set; }

    [JsonPropertyName("replies")]
    public int Replies { get; set; }

    [JsonPropertyName("hidden")]
    public string Hidden { get; set; }

    [JsonPropertyName("body")]
    public string Body { get; set; }

    [JsonPropertyName("is_liked")]
    public bool IsLiked { get; set; }

    [JsonPropertyName("is_featured")]
    public bool IsFeatured { get; set; }

    [JsonPropertyName("likes")]
    public int Likes { get; set; }

    [JsonPropertyName("user")]
    public User User { get; set; }

    [JsonPropertyName("text_content")]
    public EditorText TextContent { get; set; }
}