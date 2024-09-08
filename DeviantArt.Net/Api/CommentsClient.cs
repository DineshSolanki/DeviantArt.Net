using DeviantArt.Net.Models.Message;

namespace DeviantArt.Net.Api;

public partial class Client
{
    /// <summary>
    /// Fetches siblings of a comment. The context object includes the parent comment (if any) and the commented item.
    /// </summary>
    /// <param name="commentid">The UUID of the comment you want to fetch siblings of. Must be a valid UUID.</param>
    /// <param name="fetchRelatedItems">Optional. Fetch the related containing item (deviation, profile user, or status).</param>
    /// <param name="offset">Optional. The pagination offset. Min: -10000, Max: 10000, Default: 0.</param>
    /// <param name="limit">Optional. The pagination limit. Min: 1, Max: 50, Default: 10.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="CommentsPage"/> object.</returns>
    public async Task<CommentsPage> GetCommentSiblingsAsync(Guid commentid,
        bool? fetchRelatedItems = null,
        int? offset = null,
        int? limit = null)
    {
        return await _api.GetCommentSiblingsAsync(commentid, fetchRelatedItems, offset, limit);
    }

    /// <summary>
    /// Fetches comments posted on a deviation. Use the commentid parameter to fetch replies to a specific comment.
    /// Hidden comments are included in the response since version 20150106 and will have their body replaced with a placeholder.
    /// </summary>
    /// <param name="deviationid">The UUID of the deviation.</param>
    /// <param name="commentid">Optional. The UUID of the comment to fetch replies to. Default: null.</param>
    /// <param name="depthToQueryRepliesUntil">Optional. The depth to query replies until. Default: null.</param>
    /// <param name="offset">Optional. The pagination offset. Default: null.</param>
    /// <param name="limit">Optional. The pagination limit. Default: null.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="CommentsPage"/> object.</returns>
    public async Task<CommentsPage> GetDeviationCommentsAsync(Guid deviationid,
        Guid? commentid = null,
        int? depthToQueryRepliesUntil = null,
        int? offset = null,
        int? limit = null)
    {
        return await _api.GetDeviationCommentsAsync(deviationid, commentid, depthToQueryRepliesUntil, offset, limit);
    }

    /// <summary>
    /// Posts a comment on a deviation.
    /// </summary>
    /// <param name="deviationid">The UUID of the deviation.</param>
    /// <param name="body">The body of the comment.</param>
    /// <param name="commentid">Optional. The UUID of the comment to reply to. Default: null.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="Comment"/> object.</returns>
    public async Task<Comment> PostCommentOnDeviation(Guid deviationid,
        string body,
        Guid? commentid = null)
    {
        return await _api.PostCommentOnDeviation(deviationid, body, commentid);
    }

    /// <summary>
    /// Posts a comment on a profile.
    /// </summary>
    /// <param name="username">The username of the profile.</param>
    /// <param name="body">The body of the comment.</param>
    /// <param name="commentId">Optional. The UUID of the comment to reply to. Default: null.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="Comment"/> object.</returns>
    public async Task<Comment> PostCommentOnProfile(string username,
        string body,
        Guid? commentId = null)
    {
        return await _api.PostCommentOnProfile(username, body, commentId);
    }

    /// <summary>
    /// Posts a comment on a status.
    /// </summary>
    /// <param name="statusId">The UUID of the status.</param>
    /// <param name="body">The body of the comment.</param>
    /// <param name="commentId">Optional. The UUID of the comment to reply to. Default: null.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="Comment"/> object.</returns>
    public async Task<Comment> PostCommentOnStatus(Guid statusId,
        string body,
        Guid? commentId = null)
    {
        return await _api.PostCommentOnStatus(statusId, body, commentId);
    }

    /// <summary>
    /// Fetches comments posted on a profile.
    /// </summary>
    /// <param name="username">The username of the profile.</param>
    /// <param name="commentId">Optional. The UUID of the comment to fetch replies to. Default: null.</param>
    /// <param name="depthToQueryRepliesUntil">Optional. The depth to query replies until. Default: null.</param>
    /// <param name="offset">Optional. The pagination offset. Default: null.</param>
    /// <param name="limit">Optional. The pagination limit. Default: null.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="CommentsPage"/> object.</returns>
    public async Task<CommentsPage> GetProfileCommentsAsync(string username,
        Guid? commentId = null,
        int? depthToQueryRepliesUntil = null,
        int? offset = null,
        int? limit = null)
    {
        return await _api.GetProfileCommentsAsync(username, commentId, depthToQueryRepliesUntil, offset, limit);
    }

    /// <summary>
    /// Fetches comments posted on a status.
    /// </summary>
    /// <param name="statusId">The UUID of the status.</param>
    /// <param name="commentId">Optional. The UUID of the comment to fetch replies to. Default: null.</param>
    /// <param name="depthToQueryRepliesUntil">Optional. The depth to query replies until. Default: null.</param>
    /// <param name="offset">Optional. The pagination offset. Default: null.</param>
    /// <param name="limit">Optional. The pagination limit. Default: null.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="CommentsPage"/> object.</returns>
    public async Task<CommentsPage> GetStatusCommentsAsync(Guid statusId,
        Guid? commentId = null,
        int? depthToQueryRepliesUntil = null,
        int? offset = null,
        int? limit = null)
    {
        return await _api.GetStatusCommentsAsync(statusId, commentId, depthToQueryRepliesUntil, offset, limit);
    }
}