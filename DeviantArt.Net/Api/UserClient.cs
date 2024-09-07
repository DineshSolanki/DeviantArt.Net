using DeviantArt.Net.Models.User;
using DeviantArt.Net.Modules;

namespace DeviantArt.Net.Api;

public partial class Client
{
    /// <summary>
    /// Retrieve the dAmn auth token required to connect to the dAmn (deviantART Messaging Network) servers.
    /// The damntoken might become invalid if the user logs out of deviantART completely (via the website).
    /// However, you can still request a new damntoken through this call as long as your app remains authorized by the user.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains the DamnTokenResponse.</returns>
    public async Task<DamnTokenResponse> GetDamnAuthToken()
    {
        return await _api.GetDamnAuthToken();
    }

    /// <summary>
    /// Retrieve a list of friends for a user or self if no username is provided.
    /// </summary>
    /// <param name="username">The username to retrieve friends for. If omitted, the authenticated user is used.</param>
    /// <param name="offset">The offset for pagination. Default is 0.</param>
    /// <param name="limit">The limit for pagination. Default is null.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a PaginatedBase of Friend objects.</returns>
    public async Task<PaginatedBase<Friend>> GetFriendsOfUser(string? username = null, int? offset = 0,
        int? limit = null)
    {
        return await _api.GetFriendsOfUser(username, offset, limit);
    }

    /// <summary>
    /// Search friends by username.
    /// </summary>
    /// <param name="query">The search query. This parameter is required.</param>
    /// <param name="username">The user to search friends of. If omitted, the authenticated user is used. This parameter is optional.</param>
    /// <param name="search">Additional search parameter. This parameter is optional.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a PaginatedBase of User objects.</returns>
    public async Task<PaginatedBase<User>> SearchFriendsOfUser(string query, string? username = null,
        string? search = null)
    {
        return await _api.SearchFriendsOfUser(query, username, search);
    }

    /// <summary>
    /// Unwatch a user.
    /// </summary>
    /// <param name="username">The username of the user to unwatch.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a SimpleResponseBase indicating the success of the operation.</returns>
    /// <remarks>
    /// If the unwatch operation results in an actual user unwatch, the endpoint returns success: true. 
    /// In other cases (e.g., in case of error or if the requested user was not actually watched), it returns success: false.
    /// </remarks>
    public async Task<SimpleResponseBase> UnwatchUser(string username)
    {
        return await _api.UnwatchUser(username);
    }

    /// <summary>
    /// Watch a user.
    /// </summary>
    /// <param name="username">The username you want to watch</param>
    /// <param name="watchRequest">The types you want to watch</param>
    /// <returns></returns>
    public async Task<SimpleResponseBase> WatchUser(string username, WatchRequest watchRequest)
    {
        return await _api.WatchUser(username, watchRequest);
    }


    /// <summary>
    /// Check if a user is watching you.
    /// </summary>
    /// <param name="username">The username to check.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating if the user is watching you.</returns>
    public async Task<bool> IsUserWatchingMe(string username)
    {
        var watchingYou = await _api.CheckIfUserIsWatchingYou(username);
        return watchingYou.Watching;
    }

    /// <summary>
    /// Get user profile information.
    /// </summary>
    /// <param name="username">The username to retrieve profile for. If omitted, the authenticated user is used.</param>
    /// <param name="extCollections">Include collection folder info  information.</param>
    /// <param name="extGalleries">Include galleries folder information.</param>
    /// <param name="withSession">Include session information.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a DetailedUserProfile object.</returns>
    public async Task<DetailedUserProfile> GetUserProfile(string? username = null, bool? extCollections = null,
        bool? extGalleries = null, bool withSession = false)
    {
        return await _api.GetUserProfile(username, extCollections, extGalleries, withSession);
    }

    /// <summary>
    /// Will return all journals & status updates for a given user in a single feed.
    /// </summary>
    /// <param name="username">The username to retrieve posts for.</param>
    /// <param name="cursor">The cursor for pagination.</param>
    /// <param name="withSession">Include session information.</param>
    /// <param name="matureContent">Include mature content.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a BrowseResponse object.</returns>
    public async Task<BrowseResponse> GetUserPosts(string username, string? cursor = null, bool? withSession = false,
        bool? matureContent = null)
    {
        return await _api.GetUserPosts(username, cursor, withSession, matureContent);
    }

    /// <summary>
    /// Update user profile information.
    /// </summary>
    /// <param name="request">The profile update request containing the information to update.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a SimpleResponseBase indicating the success of the operation.</returns>
    public async Task<SimpleResponseBase> UpdateUserProfileAsync(ProfileUpdateRequest request)
    {
        var data = new Dictionary<string, object>();
        data.AddIfNotNull("user_is_artist", request.UserIsArtist);
        data.AddIfNotNull("artist_level", request.ArtistLevel?.GetDescription());
        data.AddIfNotNull("artist_specialty", request.ArtistSpecialty?.GetDescription());
        data.AddIfNotNull("countryid", request.Country.CountryId);
        data.AddIfNotNull("website", request.Website);
        data.AddIfNotNull("website_label", request.WebsiteLabel);
        data.AddIfNotNull("tagline", request.TagLine);
        data.AddIfNotNull("show_badges", request.ShowBadges);
        request.SocialLinks?.ForEach(x => data.AddIfNotNull($"social_links[{x.Type.GetDescription()}]", x.Url));
        request.Interests?.ForEach(x => data.AddIfNotNull($"interests[{x.Type.GetDescription()}]", x.Value));
        return await _api.UpdateUserProfileAsync(data);
    }

    /// <summary>
    /// Post a status.
    /// When posting a status, it is possible to share another status or deviation along with the status text. To do so, pass UUID of an object being shared (status or deviation) in id parameter. Note that it is not possible to share a status which already shares something. Sometimes the object you want to share is contained within the status. To share such object pass UUID of the containing status in parentid parameter (in addition to the id).
    /// </summary>
    /// <param name="request">The post status request containing the status information.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a PostStatusResponse object.</returns>
    public async Task<PostStatusResponse> PostStatusAsync(PostStatusRequest request)
    {
        return await _api.PostStatusAsync(request);
    }


    /// <summary>
    /// Get list of tiers for a user.
    /// </summary>
    /// <param name="username">The username to retrieve tiers for.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a PaginatedBase of Deviation objects.</returns>
    public async Task<PaginatedBase<Deviation>> GetUserTiers(string username)
    {
        return await _api.GetUserTiers(username);
    }


    /// <summary>
    /// Get list of watchers for a user.
    /// </summary>
    /// <param name="username">The username to retrieve watchers for.</param>
    /// <param name="offset">The offset for pagination. Default is 0.</param>
    /// <param name="limit">The limit for pagination. Default is null.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a PaginatedBase of Watcher objects.</returns>
    public async Task<PaginatedBase<Watcher>> GetUserWatchers(string username, int? offset = 0, int? limit = null)
    {
        return await _api.GetUserWatchers(username, offset, limit);
    }


    /// <summary>
    /// Fetch user info of authenticated user.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a User object.</returns>
    public async Task<User> WhoAmI()
    {
        return await _api.WhoAmI();
    }


    /// <summary>
    /// Fetch user info for given usernames.
    /// </summary>
    /// <param name="usernames">The usernames to retrieve info for.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a PaginatedBase of User objects.</returns>
    public async Task<PaginatedBase<User>> WhoIs(params string[] usernames)
    {
        var data = usernames.Select((username, index) => new { username, index })
            .ToDictionary(x => $"usernames[{x.index}]", x => x.username);
        return await _api.WhoIs(data);
    }
}