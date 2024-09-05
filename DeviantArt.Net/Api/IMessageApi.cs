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
}