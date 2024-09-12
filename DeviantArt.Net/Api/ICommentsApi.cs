namespace DeviantArt.Net.Api;

internal partial interface IDeviantArtApi
{
    [Get("/api/v1/oauth2/comments/{commentid}/siblings")]
    Task<CommentsPage> GetCommentSiblingsAsync(Guid commentId,
        [AliasAs("ext_item")] bool? fetchRelatedItems = null,
        [AliasAs("offset")] int? offset = null,
        [AliasAs("limit")] int? limit = null);
    
    [Get("/api/v1/oauth2/comments/deviation/{deviationId}")]
    Task<CommentsPage> GetDeviationCommentsAsync(Guid deviationId,
        [AliasAs("commentid")] Guid? commentId,
        [AliasAs("maxdepth")] int? depthToQueryRepliesUntil = null,
        [AliasAs("offset")] int? offset = null,
        [AliasAs("limit")] int? limit = null);
    
    [Post("/api/v1/oauth2/comments/post/deviation/{deviationId}")]
    Task<Comment> PostCommentOnDeviation(Guid deviationId,
        [AliasAs("body")] string body,
        [AliasAs("commentid")] Guid? commentId);
    
    [Post("/api/v1/oauth2/comments/post/profile/{username}")]
    Task<Comment> PostCommentOnProfile(string username,
        [AliasAs("body")] string body,
        [AliasAs("commentid")] Guid? commentId);
    
    [Post("/api/v1/oauth2/comments/post/status/{statusid}")]
    Task<Comment> PostCommentOnStatus(Guid statusId,
        [AliasAs("body")] string body,
        [AliasAs("commentid")] Guid? commentId);
    
    [Get("/api/v1/oauth2/comments/profile/{username}")]
    Task<CommentsPage> GetProfileCommentsAsync(string username,
        [AliasAs("commentid")] Guid? commentId,
        [AliasAs("maxdepth")] int? depthToQueryRepliesUntil = null,
        [AliasAs("offset")] int? offset = null,
        [AliasAs("limit")] int? limit = null);
    
    [Get("/api/v1/oauth2/comments/status/{statusid}")]
    Task<CommentsPage> GetStatusCommentsAsync(Guid statusId,
        [AliasAs("commentid")] Guid? commentId,
        [AliasAs("maxdepth")] int? depthToQueryRepliesUntil = null,
        [AliasAs("offset")] int? offset = null,
        [AliasAs("limit")] int? limit = null);
}