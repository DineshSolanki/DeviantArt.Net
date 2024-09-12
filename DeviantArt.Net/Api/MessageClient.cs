namespace DeviantArt.Net.Api;

public partial class Client
{
    /// <summary>
    /// Deletes a message or a message stack.
    /// </summary>
    /// <param name="messageId">The ID of the message to delete.</param>
    /// <param name="stackId">The ID of the message stack to delete.</param>
    /// <param name="folderId">The ID of the folder containing the message or stack to delete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="SimpleResponseBase"/>.</returns>
    public async Task<SimpleResponseBase> DeleteMessageAsync(string? messageId = null, string? stackId = null, string? folderId = null)
    {
        var request = new MessageRequest
        {
            MessageId = messageId,
            StackId = stackId,
            FolderId = folderId
        };
        return await _api.DeleteMessageAsync(request);
    }

    /// <summary>
    /// Gets a feed of all messages. Messages can be fetched in a stacked (default) or flat mode.
    /// In the stacked mode, similar messages will be grouped together and the most recent one will be returned.
    /// </summary>
    /// <param name="folderId">The folder to fetch messages from, defaults to inbox [must be valid UUID].</param>
    /// <param name="stackMode">True to use stacked mode, false to use flat mode.</param>
    /// <param name="cursor">The cursor for pagination.</param>
    /// <param name="withSession">Indicates whether to include session information in the request.</param>
    /// <param name="matureContent">Indicates whether to include mature content in the results.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="Message"/>.</returns>
    public async Task<Message> GetFeedAsync(string? folderId = null, bool? stackMode = null, string? cursor = null, bool withSession = false, bool? matureContent = null)
    {
        return await _api.GetFeedAsync(folderId, stackMode, cursor, withSession, matureContent);
    }

    /// <summary>
    /// Fetches feedback messages. Messages can be fetched in a stacked (default) or flat mode.
    /// In the stacked mode, similar messages will be grouped together and the most recent one will be returned.
    /// </summary>
    /// <param name="type">The type of feedback messages to fetch.</param>
    /// <param name="folderId">The folder to fetch messages from, defaults to inbox [must be valid UUID].</param>
    /// <param name="stackMode">True to use stacked mode, false to use flat mode.</param>
    /// <param name="offset">The offset for pagination.</param>
    /// <param name="limit">The limit for pagination.</param>
    /// <param name="withSession">Indicates whether to include session information in the request.</param>
    /// <param name="matureContent">Indicates whether to include mature content in the results.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="PaginatedBase{Message}"/>.</returns>
    public async Task<PaginatedBase<Message>> GetFeedbackAsync(FeedbackMessageType type, string? folderId = null, bool? stackMode = null, int? offset = 0, int? limit = null, bool withSession = false, bool? matureContent = null)
    {
        return await _api.GetFeedbackAsync(type, folderId, stackMode, offset, limit, withSession, matureContent);
    }

    /// <summary>
    /// Fetches messages in a stack.
    /// </summary>
    /// <param name="stackId">The ID of the stack to fetch messages from.</param>
    /// <param name="offset">The offset for pagination.</param>
    /// <param name="limit">The limit for pagination.</param>
    /// <param name="withSession">Indicates whether to include session information in the request.</param>
    /// <param name="matureContent">Indicates whether to include mature content in the results.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="PaginatedBase{Message}"/>.</returns>
    public async Task<PaginatedBase<Message>> GetFeedbackStackAsync(string stackId, int? offset = 0, int? limit = null, bool withSession = false, bool? matureContent = null)
    {
        return await _api.GetFeedbackStackAsync(stackId, offset, limit, withSession, matureContent);
    }

    /// <summary>
    /// Fetches mention messages. Messages can be fetched in a stacked (default) or flat mode.
    /// In the stacked mode, similar messages will be grouped together and the most recent one will be returned.
    /// </summary>
    /// <param name="folderId">The folder to fetch messages from, defaults to inbox [must be valid UUID].</param>
    /// <param name="stackMode">True to use stacked mode, false to use flat mode.</param>
    /// <param name="offset">The offset for pagination.</param>
    /// <param name="limit">The limit for pagination.</param>
    /// <param name="withSession">Indicates whether to include session information in the request.</param>
    /// <param name="matureContent">Indicates whether to include mature content in the results.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="PaginatedBase{Message}"/>.</returns>
    public async Task<PaginatedBase<Message>> GetMentionsAsync(string? folderId = null, bool? stackMode = null, int? offset = null, int? limit = null, bool withSession = false, bool? matureContent = null)
    {
        return await _api.GetMentionsAsync(folderId, stackMode, offset, limit, withSession, matureContent);
    }

    /// <summary>
    /// Fetches mention messages in a stack.
    /// </summary>
    /// <param name="stackId">The ID of the stack to fetch messages from.</param>
    /// <param name="offset">The offset for pagination.</param>
    /// <param name="limit">The limit for pagination.</param>
    /// <param name="withSession">Indicates whether to include session information in the request.</param>
    /// <param name="matureContent">Indicates whether to include mature content in the results.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="PaginatedBase{Message}"/>.</returns>
    public async Task<PaginatedBase<Message>> GetMentionsStackAsync(string stackId, int? offset = 0, int? limit = null, bool withSession = false, bool? matureContent = null)
    {
        return await _api.GetMentionsStackAsync(stackId, offset, limit, withSession, matureContent);
    }
}