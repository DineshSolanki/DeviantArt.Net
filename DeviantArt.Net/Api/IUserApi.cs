using DeviantArt.Net.Models.Deviation;
using DeviantArt.Net.Models.User;

namespace DeviantArt.Net.Api;

internal partial interface IDeviantArtApi
{
    [Get("/api/v1/oauth2/user/damntoken")]
    Task<DamnTokenResponse> GetDamnAuthToken();
    
    [Get("/api/v1/oauth2/user/friends/{username}")]
    Task<PaginatedBase<Friend>> GetFriendsOfUser(string? username = null, [AliasAs("offset")] int? offset = 0, [AliasAs("limit")] int? limit = null);
    
    [Get("/api/v1/oauth2/user/friends/search")]
    Task<PaginatedBase<User>> SearchFriendsOfUser([AliasAs("query")] string query,
        [AliasAs("username")] string? username,
        [AliasAs("search")] string? search );
    
    [Get("/api/v1/oauth2/user/friends/unwatch/{username}")]
    Task<SimpleResponseBase> UnwatchUser(string username);
    
    [Post("/api/v1/oauth2/user/friends/watch/{username}")]
    Task<SimpleResponseBase> WatchUser(string username, [Body(BodySerializationMethod.UrlEncoded)] WatchRequest watchRequest);
    
    [Get("/api/v1/oauth2/user/friends/watching/{username}")]
    Task<WatchResponse> CheckIfUserIsWatchingYou(string username);
    
    [Get("/api/v1/oauth2/user/profile/{username}")]
    Task<DetailedUserProfile> GetUserProfile(string? username = null,
        [AliasAs("ext_collections")] bool? extCollections = null,
        [AliasAs("ext_galleries")] bool? extGalleries = null,
        [AliasAs("with_session")] bool withSession = false);
    
    [Get("/api/v1/oauth2/user/profile/posts")]
    Task<BrowseResponse> GetUserPosts([AliasAs("username")] string username,
        [AliasAs("cursor")] string? cursor = null,
        [AliasAs("with_session")] bool? withSession = false,
        [AliasAs("mature_content")] bool? matureContent = null);
    
    [Post("/api/v1/oauth2/user/profile/update")]
    Task<SimpleResponseBase> UpdateUserProfileAsync([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> data);
    
    [Post("/api/v1/oauth2/user/statuses/post")]
    Task<PostStatusResponse> PostStatusAsync([Body(BodySerializationMethod.UrlEncoded)] PostStatusRequest request);
    
    [Get("/api/v1/oauth2/user/tiers/{username}")]
    Task<PaginatedBase<Deviation>> GetUserTiers(string username);
    
    [Get("/api/v1/oauth2/user/watchers/{username}")]
    Task<PaginatedBase<Watcher>> GetUserWatchers(string username, [AliasAs("offset")] int? offset = 0, [AliasAs("limit")] int? limit = null);
    
    [Get("/api/v1/oauth2/user/whoami")]
    Task<User> WhoAmI();
    
    [Post("/api/v1/oauth2/user/whois")]
    Task<PaginatedBase<User>> WhoIs([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, string> usernames);
}