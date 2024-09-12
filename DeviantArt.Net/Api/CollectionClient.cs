using DeviantArt.Net.Models.Deviation;
using DeviantArt.Net.Models.User;
using DeviantArt.Net.Modules;

namespace DeviantArt.Net.Api;

public partial class Client
{
    /// <summary>
    /// Fetches the contents of a collection folder.
    /// </summary>
    /// <param name="folderId">The ID of the collection folder.</param>
    /// <param name="offset">The offset for pagination.</param>
    /// <param name="limit">The maximum number of deviations to retrieve.</param>
    /// <param name="withSession">Whether to include session information.</param>
    /// <param name="matureContent">Whether to include mature content.</param>
    /// <returns>A paginated list of deviations.</returns>
    public async Task<PaginatedBase<Deviation>> GetCollectionAsync(Guid folderId, int? offset = null, int? limit = null, bool? withSession = null, bool? matureContent = null)
    {
        return await _api.GetCollection(folderId, offset, limit, withSession, matureContent);
    }

    /// <summary>
    /// Creates a new collection folder.
    /// </summary>
    /// <param name="collectionName">The name of the new collection folder.</param>
    /// <returns>The created folder.</returns>
    public async Task<Folder> CreateCollectionAsync(string collectionName)
    {
        return await _api.CreateCollection(new Dictionary<string, object> {{"folder", collectionName}});
    }

    /// <summary>
    /// Fetches deviations from all collection folders.
    /// </summary>
    /// <param name="username">The username of the user whose collections are to be retrieved. If null, retrieves the authenticated user's collections.</param>
    /// <param name="offset">The offset for pagination.</param>
    /// <param name="limit">The maximum number of deviations to retrieve.</param>
    /// <param name="withSession">Whether to include session information.</param>
    /// <param name="matureContent">Whether to include mature content.</param>
    /// <returns>A paginated list of deviations.</returns>
    public async Task<PaginatedBase<Deviation>> GetFromAllCollectionsAsync(string? username = null, int? offset = null, int? limit = null, bool? withSession = null, bool? matureContent = null)
    {
        return await _api.GetFromAllCollections(username, offset, limit, withSession, matureContent);
    }

    /// <summary>
    /// Fetches all collection folders.
    /// </summary>
    /// <param name="username">The username of the user whose collection folders are to be retrieved. If null, retrieves the authenticated user's collection folders.</param>
    /// <param name="calculateSize">Whether to calculate the size of each folder.</param>
    /// <param name="extPreload">Whether to preload extended information.</param>
    /// <param name="filterEmptyFolder">Filter to exclude empty folders.</param>
    /// <param name="offset">The offset for pagination.</param>
    /// <param name="limit">The maximum number of folders to retrieve.</param>
    /// <param name="withSession">Whether to include session information.</param>
    /// <param name="matureContent">Whether to include mature content.</param>
    /// <returns>A paginated list of collection folders.</returns>
    public async Task<PaginatedBase<CollectionFolder>> GetAllCollectionsAsync(string? username = null, bool? calculateSize = null, bool? extPreload = null, bool? filterEmptyFolder = null, int? offset = null, int? limit = null, bool? withSession = null, bool? matureContent = null)
    {
        return await _api.GetAllCollections(username, calculateSize, extPreload, filterEmptyFolder, offset, limit, withSession, matureContent);
    }

    /// <summary>
    /// Adds deviations to favorites, optionally into a collection folder.
    /// </summary>
    /// <param name="deviationId">The ID of the deviation to add to favorites.</param>
    /// <param name="collectionIds">The list of collection folder IDs to add the deviation to. If null, adds to the Featured collection.</param>
    /// <returns>A simple response indicating the result of the operation.</returns>
    public async Task<SimpleResponseBase> AddDeviationsToFavouritesAsync(Guid deviationId, List<Guid>? collectionIds = null)
    {
        var request = new Dictionary<string, object> {{"deviationid", deviationId}};
        request.AddIfNotNull("folderid", collectionIds);
        return await _api.AddDeviationsToFavourites(request);
    }

    /// <summary>
    /// Copies a list of deviations to a collection.
    /// </summary>
    /// <param name="copyDeviationsRequest">The request containing the target folder ID and the list of deviation IDs to copy.</param>
    /// <returns>A simple response indicating the result of the operation.</returns>
    public async Task<SimpleResponseBase> CopyDeviationsToCollectionAsync(CopyDeviationsRequest copyDeviationsRequest)
    {
        var requestDictionary = new Dictionary<string, object>
        {
            { "target_folderid", copyDeviationsRequest.TargetFolderId },
        };
        requestDictionary.AddEnumerable("deviationids", copyDeviationsRequest.DeviationIds);
        return await _api.CopyDeviationsToCollection(requestDictionary);
    }

    /// <summary>
    /// Moves a list of deviations to a collection.
    /// </summary>
    /// <param name="moveDeviationsRequest">The request containing the target folder ID, source folder ID, and the list of deviation IDs to move.</param>
    /// <returns>A simple response indicating the result of the operation.</returns>
    public async Task<SimpleResponseBase> MoveDeviationsToCollectionAsync(MoveDeviationsRequest moveDeviationsRequest)
    {
        var requestDictionary = new Dictionary<string, object>
        {
            { "target_folderid", moveDeviationsRequest.TargetFolderId },
            { "source_folderid", moveDeviationsRequest.SourceFolderId }
        };
        requestDictionary.AddEnumerable("deviationids", moveDeviationsRequest.DeviationIds);
        return await _api.MoveDeviationsToCollection(requestDictionary);
    }

    /// <summary>
    /// Removes a collection folder.
    /// </summary>
    /// <param name="folderId">The ID of the collection folder to remove.</param>
    /// <returns>A simple response indicating the result of the operation.</returns>
    public async Task<SimpleResponseBase> RemoveCollectionAsync(Guid folderId)
    {
        return await _api.RemoveCollection(folderId);
    }

    /// <summary>
    /// Removes a list of deviations from a collection.
    /// </summary>
    /// <param name="folderId">The ID of the collection folder.</param>
    /// <param name="deviationIds">The list of deviation IDs to remove.</param>
    /// <returns>A simple response indicating the result of the operation.</returns>
    public async Task<SimpleResponseBase> RemoveDeviationsFromCollectionAsync(Guid folderId, List<Guid> deviationIds)
    {
        var requestDictionary = new Dictionary<string, object>
        {
            { " folderid ", folderId }
        };
        requestDictionary.AddEnumerable("deviationids", deviationIds);
        return await _api.RemoveDeviationsFromCollection(requestDictionary);
    }

    /// <summary>
    /// Updates a collection folder.
    /// </summary>
    /// <param name="folderId">The ID of the collection folder to update.</param>
    /// <param name="name">The new name of the collection folder.</param>
    /// <param name="description">The new description of the collection folder.</param>
    /// <param name="coverDeviationId">The ID of the cover deviation.</param>
    /// <returns>A simple response indicating the result of the operation.</returns>
    public async Task<SimpleResponseBase> UpdateCollectionAsync(Guid folderId, string? name, string? description = null, Guid? coverDeviationId = null)
    {
        var request = new Dictionary<string, object>
        {
            { "folderid", folderId },
        };
        request.AddIfNotNull("name", name);
        request.AddIfNotNull("description", description);
        request.AddIfNotNull("cover_deviationid", coverDeviationId);
        return await _api.UpdateCollection(request);
    }

    /// <summary>
    /// Updates the order of deviations in a collection folder.
    /// </summary>
    /// <param name="folderId">The ID of the collection folder.</param>
    /// <param name="deviationId">The ID of the deviation to reorder.</param>
    /// <param name="position">The new position of the deviation.</param>
    /// <returns>A simple response indicating the result of the operation.</returns>
    public async Task<SimpleResponseBase> UpdateDeviationOrderCollectionAsync(Guid folderId, Guid deviationId, int position)
    {
        var request = new Dictionary<string, object>
        {
            { "folderid", folderId }
        };
        request.AddIfNotNull("deviationid", deviationId);
        request.AddIfNotNull("position", position);
        return await _api.UpdateDeviationOrderCollection(request);
    }

    /// <summary>
    /// Rearranges the position of collection folders.
    /// </summary>
    /// <param name="folderId">The ID of the collection folder.</param>
    /// <param name="position">The new position of the collection folder.</param>
    /// <returns>A simple response indicating the result of the operation.</returns>
    public async Task<SimpleResponseBase> UpdateCollectionOrderAsync(Guid folderId, int position)
    {
        var request = new Dictionary<string, object>
        {
            { "folderid", folderId },
            { "position", position }
        };
        return await _api.UpdateOrderCollection(request);
    }

    /// <summary>
    /// Removes a list of deviations from favorites.
    /// </summary>
    /// <param name="deviationId">The ID of the deviation to remove from favorites.</param>
    /// <param name="folderId">Optional UUID remove from a single collection folder</param>
    /// <returns>A simple response indicating the result of the operation.</returns>
    public async Task<SimpleResponseBase> RemoveDeviationsFromFavouritesAsync(Guid deviationId, List<Guid>? folderId = null)
    {
        var request = new Dictionary<string, object> {{"deviationid", deviationId}};
        request.AddIfNotNull("folderid", folderId);
        return await _api.RemoveDeviationsFromFavourites(request);
    }
}