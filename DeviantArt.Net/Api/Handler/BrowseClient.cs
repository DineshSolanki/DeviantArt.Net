using System.Linq.Expressions;
using DeviantArt.Net.Modules.Util;

namespace DeviantArt.Net.Api;

public partial class Client
{
    public async Task<BrowseResponse> GetDailyDeviationsAsync(DateOnly date, bool withSession = false, bool? matureContent = null)
    {
        return await _api.GetDailyDeviationsAsync(date, withSession, matureContent);
    }
    
    /// <summary>
    /// Get deviations of deviants you watch
    /// </summary>
    /// <param name="offset"></param>
    /// <param name="limit"></param>
    /// <param name="withSession"></param>
    /// <param name="matureContent"></param>
    /// <returns></returns>
    public async Task<BrowseResponse> GetDeviantsYouWatchAsync(int? offset = null, int? limit = null, bool withSession = false, bool? matureContent = null)
    {
        return await _api.GetDeviantsYouWatchAsync(offset, limit, withSession, matureContent);
    }
    
    public async Task<PaginatedBase<Deviation>> BrowseHomeDeviationsAsync(string? query = null, int? limit = null, int? offset = null, bool? matureContent = null)
    {
        return await _api.GetHomeDeviationsAsync(query,limit, offset, matureContent);
    }
    
    //Browse a tag 
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
    
    //Fetch More Like This preview result for a seed deviation 
    public async Task<SeededResponse> GetMoreLikeThisPreviewAsync(string deviationId, bool? matureContent = null)
    {
        return await _api.GetMoreLikeThisPreviewAsync(deviationId, matureContent);
    }
    
    //Autocomplete tags
    public async Task<TagNamesResponse> BrowseTagsSearchAsync(string tagName, bool withSession = false, bool? matureContent = null)
    {
        return await _api.BrowseTagsSearchAsync(tagName, withSession, matureContent);
    }
    
    //Fetch topic deviations
    public async Task<BrowseResponse> BrowseTopicAsync(string topic,
        string? cursor = null,
        int? offset = null,
        int? limit = null,
        bool withSession = false,
        bool? matureContent = null)
    {
        return await _api.BrowseTopicAsync(topic, cursor, offset, limit, withSession, matureContent);
    }
    
    //Fetch topics and deviations from each topic
    public async Task<TopicsResponse> BrowseTopicsAsync(
        string? cursor = null,
        int? offset = null,
        int? limit = null,
        bool withSession = false,
        bool? matureContent = null)
    {
        return await _api.BrowseTopicsAsync(cursor, offset, limit, withSession, matureContent);
    }
    
    //Fetch top topics with example deviation for each one 
    public async Task<TopicsResponse> BrowseTopTopicsAsync(bool withSession = false, bool? matureContent = null)
    {
        return await _api.BrowseTopTopicsAsync(withSession, matureContent);
    }
}