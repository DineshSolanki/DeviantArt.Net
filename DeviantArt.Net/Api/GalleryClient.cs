using DeviantArt.Net.Models.Deviation;
using DeviantArt.Net.Models.User;
using DeviantArt.Net.Modules;

namespace DeviantArt.Net.Api;

/// <summary>
/// Client class for interacting with DeviantArt gallery-related API endpoints.
/// </summary>
public partial class Client
{
    /// <summary>
    /// Retrieves a paginated list of gallery folders for a user.
    /// </summary>
    /// <param name="username">The username of the user whose gallery folders are to be retrieved. If null, retrieves the authenticated user's gallery folders.</param>
    /// <param name="calculateSize">Whether to calculate the size of each folder.</param>
    /// <param name="extPreload">Whether to preload extended information.</param>
    /// <param name="filterEmptyFolder">Filter to exclude empty folders.</param>
    /// <param name="offset">The offset for pagination.</param>
    /// <param name="limit">The maximum number of folders to retrieve.</param>
    /// <param name="withSession">Whether to include session information.</param>
    /// <returns>A paginated list of gallery folders.</returns>
    public async Task<PaginatedBase<GalleryFolder>> GetGalleryFoldersAsync(string? username = null,
        bool? calculateSize = null, bool? extPreload = null, string? filterEmptyFolder = null, int? offset = null, int? limit = null,
        bool? withSession = null)
    {
        return await _api.GetGalleryFoldersAsync(username, calculateSize, extPreload, filterEmptyFolder, offset, limit, withSession);
    }

    /// <summary>
    /// Retrieves a paginated list of deviations in a specific gallery folder.
    /// </summary>
    /// <param name="folderId">The ID of the folder. If null, retrieves deviations from all folders.</param>
    /// <param name="username">The username of the user whose gallery folder is to be retrieved. If null, retrieves the authenticated user's gallery folder.</param>
    /// <param name="sortBy">The sorting order of the deviations.</param>
    /// <param name="offset">The offset for pagination.</param>
    /// <param name="limit">The maximum number of deviations to retrieve.</param>
    /// <param name="withSession">Whether to include session information.</param>
    /// <param name="matureContent">Whether to include mature content.</param>
    /// <returns>A paginated list of deviations.</returns>
    public async Task<PaginatedBase<Deviation>> GetGalleryFolderAsync(Guid? folderId = null, string? username = null, Sort? sortBy = null, int? offset = null, int? limit = null,
        bool withSession = false, bool? matureContent = null)
    {
        return await _api.GetGalleryFolderAsync(folderId, username, sortBy, offset, limit, withSession, matureContent);
    }

    /// <summary>
    /// Retrieves a paginated list of all deviations in a user's gallery.
    /// </summary>
    /// <param name="username">The username of the user whose gallery is to be retrieved. If null, retrieves the authenticated user's gallery.</param>
    /// <param name="offset">The offset for pagination.</param>
    /// <param name="limit">The maximum number of deviations to retrieve.</param>
    /// <param name="withSession">Whether to include session information.</param>
    /// <param name="matureContent">Whether to include mature content.</param>
    /// <returns>A paginated list of deviations.</returns>
    public async Task<PaginatedBase<Deviation>> GetAllGalleryFoldersAsync(string? username = null, int? offset = null, int? limit = null,
        bool withSession = false, bool? matureContent = null)
    {
        return await _api.GetAllGalleryFoldersAsync(username, offset, limit, withSession, matureContent);
    }

    /// <summary>
    /// Copies a list of deviations to a specified folder.
    /// </summary>
    /// <param name="request">The request containing the target folder ID and the list of deviation IDs to copy.</param>
    /// <returns>A simple response indicating the result of the operation.</returns>
    public async Task<SimpleResponseBase> CopyDeviationsAsync(CopyDeviationsRequest request)
    {
        var requeDictionary = new Dictionary<string, object>
        {
            { "target_folderid", request.TargetFolderId },
        };
        requeDictionary.AddEnumerable("deviationids", request.DeviationIds);
        return await _api.CopyDeviationsAsync(requeDictionary);
    }

    /// <summary>
    /// Moves a list of deviations to a specified folder.
    /// </summary>
    /// <param name="request">The request containing the target folder ID, source folder ID, and the list of deviation IDs to move.</param>
    /// <returns>A simple response indicating the result of the operation.</returns>
    public async Task<SimpleResponseBase> MoveDeviationsAsync(MoveDeviationsRequest request)
    {
        var requeDictionary = new Dictionary<string, object>
        {
            { "target_folderid", request.TargetFolderId },
            { "source_folderid", request.SourceFolderId }
        };
        requeDictionary.AddEnumerable("deviationids", request.DeviationIds);
        return await _api.MoveDeviationsAsync(requeDictionary);
    }

    /// <summary>
    /// Removes a list of deviations from a specified folder.
    /// </summary>
    /// <param name="folderId">The ID of the folder from which to remove the deviations.</param>
    /// <param name="deviationIds">The list of deviation IDs to remove.</param>
    /// <returns>A simple response indicating the result of the operation.</returns>
    public async Task<SimpleResponseBase> RemoveDeviationsFromGalleryAsync(Guid folderId, List<Guid> deviationIds)
    {
        var request = new Dictionary<string, object>
        {
            { "folderid", folderId }
        };
        request.AddEnumerable("deviationids", deviationIds);
        return await _api.RemoveDeviationsFromGalleryAsync(request);
    }

    /// <summary>
    /// Creates a new gallery folder.
    /// </summary>
    /// <param name="name">The name of the new folder.</param>
    /// <param name="description">The description of the new folder.</param>
    /// <param name="parentId">The ID of the parent folder, if any.</param>
    /// <returns>The created folder.</returns>
    public async Task<Folder> CreateGalleryFolderAsync(string name, string? description, Guid? parentId = null)
    {
        var request = new Dictionary<string, object>
        {
            { "folder", name }
        };
        request.AddIfNotNull("description", description);
        request.AddIfNotNull("parent_folderid", parentId);
        return await _api.CreateGalleryFolderAsync(request);
    }

    /// <summary>
    /// Deletes a specified folder.
    /// </summary>
    /// <param name="folderId">The ID of the folder to delete.</param>
    /// <returns>A simple response indicating the result of the operation.</returns>
    public async Task<SimpleResponseBase> DeleteFolderAsync(Guid folderId)
    {
        return await _api.DeleteFolderAsync(folderId);
    }

    /// <summary>
    /// Moves a folder to a new parent folder.
    /// </summary>
    /// <param name="folderId">The ID of the folder to move.</param>
    /// <param name="newParentId">The ID of the new parent folder.</param>
    /// <returns>A simple response indicating the result of the operation.</returns>
    public async Task<SimpleResponseBase> MoveFolderAsync(Guid folderId, Guid newParentId)
    {
        var request = new Dictionary<string, object>
        {
            { "folderid", folderId },
            { "to_folderid", newParentId }
        };
        return await _api.MoveFolderAsync(request);
    }

    /// <summary>
    /// Updates a specified folder. Empty or null values clear the corresponding field.
    /// </summary>
    /// <param name="folderId">The ID of the folder to update.</param>
    /// <param name="name">The new name of the folder.</param>
    /// <param name="description">The new description of the folder.</param>
    /// <param name="coverDeviationId">The ID of the cover deviation.</param>
    /// <returns>A simple response indicating the result of the operation.</returns>
    public async Task<SimpleResponseBase> UpdateFolderAsync(Guid folderId, string name, string? description = null, Guid? coverDeviationId = null)
    {
        var request = new Dictionary<string, object>
        {
            { "folderid", folderId },
        };
        request.AddIfNotNull("name", name);
        request.AddIfNotNull("description", description);
        request.AddIfNotNull("cover_deviationid", coverDeviationId);
        return await _api.UpdateFolderAsync(request);
    }

    /// <summary>
    /// Updates the order of deviations in a specified folder.
    /// </summary>
    /// <param name="folderId">The ID of the folder.</param>
    /// <param name="deviationId">The ID of the deviation to reorder.</param>
    /// <param name="position">The new position of the deviation.</param>
    /// <returns>A simple response indicating the result of the operation.</returns>
    public async Task<SimpleResponseBase> UpdateDeviationOrderAsync(Guid folderId, Guid deviationId, int position)
    {
        var request = new Dictionary<string, object>
        {
            { "folderid", folderId }
        };
        request.AddIfNotNull("deviationid", deviationId);
        request.AddIfNotNull("position", position);
        return await _api.UpdateDeviationOrderAsync(request);
    }

    /// <summary>
    /// Updates the order of a specified folder.
    /// </summary>
    /// <param name="folderId">The ID of the folder.</param>
    /// <param name="position">The new position of the folder.</param>
    /// <returns>A simple response indicating the result of the operation.</returns>
    public async Task<SimpleResponseBase> UpdateFolderOrderAsync(Guid folderId, int position)
    {
        var request = new Dictionary<string, object>
        {
            { "folderid", folderId },
            { "position", position }
        };
        return await _api.UpdateFolderOrderAsync(request);
    }
}