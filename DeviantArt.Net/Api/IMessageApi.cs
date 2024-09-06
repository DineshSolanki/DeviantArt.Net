using DeviantArt.Net.Models.Message;

namespace DeviantArt.Net.Api;

internal partial interface IDeviantArtApi
{
    [Post("/api/v1/oauth2/messages/delete/")]
    Task<MessageResponseBase> DeleteMessageAsync([Body(BodySerializationMethod.UrlEncoded)] MessageRequest request);
    
    [Get("/api/v1/oauth2/messages/feed")]
    Task<Message> GetFeedAsync([AliasAs("folderid")] string? folderId = null,
        [AliasAs("stack")] bool? stackMode = null,
        [AliasAs("cursor")] string? cursor = null,
        [AliasAs("with_session")] bool withSession = false,
        [AliasAs("mature_content")] bool? matureContent = null);
    
    [Get("/api/v1/oauth2/messages/feedback")]
    Task<PaginatedBase<Message>> GetFeedbackAsync( [AliasAs("type")] FeedbackMessageType type,
        [AliasAs("folderid")] string? folderId = null,
        [AliasAs("stack")] bool? stackMode = null,
        [AliasAs("offset")] int? offset = 0, 
        [AliasAs("limit")] int? limit = null,
        [AliasAs("with_session")] bool withSession = false,
        [AliasAs("mature_content")] bool? matureContent = null);
    
    [Get("/api/v1/oauth2/messages/feedback/{stackid}")]
    Task<PaginatedBase<Message>> GetFeedbackStackAsync(string stackId,
        [AliasAs("offset")] int? offset = 0, 
        [AliasAs("limit")] int? limit = null,
        [AliasAs("with_session")] bool withSession = false,
        [AliasAs("mature_content")] bool? matureContent = null);
    
    [Get("/api/v1/oauth2/messages/mentions")]
    Task<PaginatedBase<Message>> GetMentionsAsync([AliasAs("folderid")] string? folderId = null,
        [AliasAs("stack")] bool? stackMode = null,
        [AliasAs("offset")] int? offset = null,
        [AliasAs("limit")] int? limit = null,
        [AliasAs("with_session")] bool withSession = false,
        [AliasAs("mature_content")] bool? matureContent = null);
    
    [Get("/api/v1/oauth2/messages/mentions/{stackid}")]
    Task<PaginatedBase<Message>> GetMentionsStackAsync(string stackId,
        [AliasAs("offset")] int? offset = 0, 
        [AliasAs("limit")] int? limit = null,
        [AliasAs("with_session")] bool withSession = false,
        [AliasAs("mature_content")] bool? matureContent = null);
}