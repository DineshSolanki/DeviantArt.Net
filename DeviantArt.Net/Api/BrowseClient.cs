using DeviantArt.Net.Models.Deviation;

namespace DeviantArt.Net.Api;

public partial class Client
{
    /// <summary>
    /// Asynchronously retrieves the daily deviations for a specified date.
    /// </summary>
    /// <param name="date">The date for which to retrieve daily deviations.</param>
    /// <param name="withSession">Indicates whether to include session information in the request.</param>
    /// <param name="matureContent">Indicates whether to include mature content in the results.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the daily deviations.</returns>
    public async Task<BrowseResponse> GetDailyDeviationsAsync(DateOnly date, bool withSession = false, bool? matureContent = null)
    {
        return await _api.GetDailyDeviationsAsync(date, withSession, matureContent);
    }

    /// <summary>
    /// Asynchronously retrieves the deviations from the deviants that the user watches.
    /// </summary>
    /// <param name="offset">The offset for pagination.</param>
    /// <param name="limit">The maximum number of deviations to retrieve.</param>
    /// <param name="withSession">Indicates whether to include session information in the request.</param>
    /// <param name="matureContent">Indicates whether to include mature content in the results.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the deviations from the watched deviants.</returns>
    public async Task<BrowseResponse> GetDeviantsYouWatchAsync(int? offset = null, int? limit = null, bool withSession = false, bool? matureContent = null)
    {
        return await _api.GetDeviantsYouWatchAsync(offset, limit, withSession, matureContent);
    }

    /// <summary>
    /// Asynchronously retrieves the home deviations based on the specified parameters.
    /// </summary>
    /// <param name="query">The search query.</param>
    /// <param name="limit">The maximum number of deviations to retrieve.</param>
    /// <param name="offset">The offset for pagination.</param>
    /// <param name="matureContent">Indicates whether to include mature content in the results.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the home deviations.</returns>
    public async Task<PaginatedBase<Deviation>> BrowseHomeDeviationsAsync(string? query = null, int? limit = null, int? offset = null, bool? matureContent = null)
    {
        return await _api.GetHomeDeviationsAsync(query, limit, offset, matureContent);
    }

    /// <summary>
    /// Asynchronously retrieves deviations for a specified tag.
    /// </summary>
    /// <param name="tag">The tag to browse.</param>
    /// <param name="cursor">The cursor for pagination.</param>
    /// <param name="offset">The offset for pagination.</param>
    /// <param name="limit">The maximum number of deviations to retrieve.</param>
    /// <param name="withSession">Indicates whether to include session information in the request.</param>
    /// <param name="matureContent">Indicates whether to include mature content in the results.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the deviations for the specified tag.</returns>
    public async Task<BrowseResponse> BrowseTagsAsync(
        string tag,
        string? cursor = null,
        int? offset = null,
        int? limit = null,
        bool withSession = false,
        bool? matureContent = null)
    {
        return await _api.BrowseTagsAsync(tag, cursor, offset, limit, withSession, matureContent);
    }

    /// <summary>
    /// Asynchronously retrieves a preview of deviations similar to a specified seed deviation.
    /// </summary>
    /// <param name="deviationId">The ID of the seed deviation.</param>
    /// <param name="matureContent">Indicates whether to include mature content in the results.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the preview of similar deviations.</returns>
    public async Task<SeededResponse> GetMoreLikeThisPreviewAsync(Guid deviationId, bool? matureContent = null)
    {
        return await _api.GetMoreLikeThisPreviewAsync(deviationId, matureContent);
    }

    /// <summary>
    /// Asynchronously retrieves autocomplete suggestions for tags.
    /// </summary>
    /// <param name="tagName">The tag name to search for.</param>
    /// <param name="withSession">Indicates whether to include session information in the request.</param>
    /// <param name="matureContent">Indicates whether to include mature content in the results.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the autocomplete suggestions for tags.</returns>
    public async Task<TagNamesResponse> BrowseTagsSearchAsync(string tagName, bool withSession = false, bool? matureContent = null)
    {
        return await _api.BrowseTagsSearchAsync(tagName, withSession, matureContent);
    }

    /// <summary>
    /// Asynchronously retrieves deviations for a specified topic.
    /// </summary>
    /// <param name="topic">The topic to browse.</param>
    /// <param name="cursor">The cursor for pagination.</param>
    /// <param name="offset">The offset for pagination.</param>
    /// <param name="limit">The maximum number of deviations to retrieve.</param>
    /// <param name="withSession">Indicates whether to include session information in the request.</param>
    /// <param name="matureContent">Indicates whether to include mature content in the results.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the deviations for the specified topic.</returns>
    public async Task<BrowseResponse> BrowseTopicAsync(string topic,
        string? cursor = null,
        int? offset = null,
        int? limit = null,
        bool withSession = false,
        bool? matureContent = null)
    {
        return await _api.BrowseTopicAsync(topic, cursor, offset, limit, withSession, matureContent);
    }

    /// <summary>
    /// Asynchronously retrieves topics and deviations from each topic.
    /// </summary>
    /// <param name="cursor">The cursor for pagination.</param>
    /// <param name="offset">The offset for pagination.</param>
    /// <param name="limit">The maximum number of topics to retrieve.</param>
    /// <param name="withSession">Indicates whether to include session information in the request.</param>
    /// <param name="matureContent">Indicates whether to include mature content in the results.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the topics and deviations from each topic.</returns>
    public async Task<TopicsResponse> BrowseTopicsAsync(
        string? cursor = null,
        int? offset = null,
        int? limit = null,
        bool withSession = false,
        bool? matureContent = null)
    {
        return await _api.BrowseTopicsAsync(cursor, offset, limit, withSession, matureContent);
    }

    /// <summary>
    /// Asynchronously retrieves the top topics with an example deviation for each one.
    /// </summary>
    /// <param name="withSession">Indicates whether to include session information in the request.</param>
    /// <param name="matureContent">Indicates whether to include mature content in the results.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the top topics with an example deviation for each one.</returns>
    public async Task<TopicsResponse> BrowseTopTopicsAsync(bool withSession = false, bool? matureContent = null)
    {
        return await _api.BrowseTopTopicsAsync(withSession, matureContent);
    }
}