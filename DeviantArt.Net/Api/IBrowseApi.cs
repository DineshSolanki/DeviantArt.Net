namespace DeviantArt.Net.Api;

internal partial interface IDeviantArtApi
{
    [Get("/api/v1/oauth2/browse/dailydeviations")]
    Task<BrowseResponse> GetDailyDeviationsAsync([AliasAs("date")] DateOnly date, 
        [AliasAs("with_session")] bool withSession = false,
        [AliasAs("mature_content")] bool? matureContent = null);
    
    [Get("/api/v1/oauth2/browse/deviantsyouwatch")]
    Task<BrowseResponse> GetDeviantsYouWatchAsync([AliasAs("offset")] int? offset = 0, 
        [AliasAs("limit")] int? limit = null,
        [AliasAs("with_session")] bool withSession = false,
        [AliasAs("mature_content")] bool? matureContent = null);
    
    [Get("/api/v1/oauth2/browse/home")]
    Task<PaginatedBase<Deviation>> GetHomeDeviationsAsync([AliasAs("q") ]string? query = null,
        [AliasAs("offset")] int? offset = null,
        [AliasAs("limit")] int? limit = null,
        [AliasAs("mature_content")] bool? matureContent = null);
    
    [Get("/api/v1/oauth2/browse/morelikethis/preview")]
    Task<SeededResponse> GetMoreLikeThisPreviewAsync([AliasAs("seed")] string deviationId,
        [AliasAs("mature_content")] bool? matureContent = null);
    
    [Get("/api/v1/oauth2/browse/tags")]
    Task<BrowseResponse> BrowseTagsAsync(
        [AliasAs("tag")] string tag,
        [AliasAs("cursor")] string? cursor = null,
        [AliasAs("offset")] int? offset = null,
        [AliasAs("limit")] int? limit = null,
        [AliasAs("with_session")] bool withSession = false,
        [AliasAs("mature_content")] bool? matureContent = null);
    
    [Get("/api/v1/oauth2/browse/tags/search")]
    Task<TagNamesResponse> BrowseTagsSearchAsync(
        [AliasAs("tag_name")] string tagName,
        [AliasAs("with_session")] bool withSession = false,
        [AliasAs("mature_content")] bool? matureContent = null);
    
    [Get("/api/v1/oauth2/browse/topic")]
    Task<BrowseResponse> BrowseTopicAsync(
        [AliasAs("topic")] string topic,
        [AliasAs("cursor")] string? cursor = null,
        [AliasAs("offset")] int? offset = null,
        [AliasAs("limit")] int? limit = null,
        [AliasAs("with_session")] bool withSession = false,
        [AliasAs("mature_content")] bool? matureContent = null);
    
    [Get("/api/v1/oauth2/browse/topics")]
    Task<TopicsResponse> BrowseTopicsAsync(
        [AliasAs("cursor")] string? cursor = null,
        [AliasAs("offset")] int? offset = null,
        [AliasAs("limit")] int? limit = null,
        [AliasAs("with_session")] bool withSession = false,
        [AliasAs("mature_content")] bool? matureContent = null);
    
    [Get("/api/v1/oauth2/browse/toptopics")]
    Task<TopicsResponse> BrowseTopTopicsAsync(
        [AliasAs("with_session")] bool withSession = false,
        [AliasAs("mature_content")] bool? matureContent = null);
}