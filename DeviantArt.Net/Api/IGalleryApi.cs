namespace DeviantArt.Net.Api;

internal partial interface IDeviantArtApi
{
    [Get("/api/v1/oauth2/gallery/folders")]
    Task<PaginatedBase<GalleryFolder>> GetGalleryFoldersAsync([Query] string? username, 
        [AliasAs("calculate_size")] bool? calculateSize,
        [AliasAs("ext_preload")] bool? extPreload,
        [AliasAs("filter_empty_folder")] bool? filterEmptyFolder,
        [Query] int? offset, 
        [Query] int? limit,
        [AliasAs("with_session")] bool? withSession);
    
    [Get("/api/v1/oauth2/gallery/{folderId}")]
    Task<PaginatedBase<Deviation>> GetGalleryFolderAsync(Guid? folderId,
        [AliasAs("username")] string? username,
        [AliasAs("mode")] Sort? mode,
        [AliasAs("offset")] int? offset = null,
        [AliasAs("limit")] int? limit = null,
        [AliasAs("with_session")] bool withSession = false,
        [AliasAs("mature_content")] bool? matureContent = null);
    
    [Get("/api/v1/oauth2/gallery/all")]
    Task<PaginatedBase<Deviation>> GetAllGalleryFoldersAsync([Query] string? username, 
        [AliasAs("offset")] int? offset = null,
        [AliasAs("limit")] int? limit = null,
        [AliasAs("with_session")] bool withSession = false,
        [AliasAs("mature_content")] bool? matureContent = null);
    
    [Post("/api/v1/oauth2/gallery/folders/copy_deviations")]
    Task<SimpleResponseBase> CopyDeviationsAsync([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> request);
    
    [Post("/api/v1/oauth2/gallery/folders/move_deviations")]
    Task<SimpleResponseBase> MoveDeviationsAsync([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> request);
    
    [Post("/api/v1/oauth2/gallery/folders/remove_deviations")]
    Task<SimpleResponseBase> RemoveDeviationsFromGalleryAsync([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> request);

    [Post("/api/v1/oauth2/gallery/folders/create")]
    Task<Folder> CreateGalleryFolderAsync([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> request);
    
    [Post("/api/v1/oauth2/gallery/folders/remove/{folderid}")]
    Task<SimpleResponseBase> DeleteFolderAsync(Guid folderId);

    [Post("/api/v1/oauth2/gallery/folders/move")]
    Task<SimpleResponseBase> MoveFolderAsync([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> request);
    
    [Post("/api/v1/oauth2/gallery/folders/update")]
    Task<SimpleResponseBase> UpdateFolderAsync([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> request);
    
    [Post("/api/v1/oauth2/gallery/folders/update_deviation_order")]
    Task<SimpleResponseBase> UpdateDeviationOrderAsync([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> request);
    
    [Post("/api/v1/oauth2/gallery/folders/update_order")]
    Task<SimpleResponseBase> UpdateFolderOrderAsync([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> request);
}