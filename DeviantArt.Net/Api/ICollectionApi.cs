namespace DeviantArt.Net.Api;

internal partial interface IDeviantArtApi
{
    [Get("/api/v1/oauth2/collections/{folderId}")]
    Task<PaginatedBase<Deviation>> GetCollection(Guid folderId,  
        [AliasAs("offset")] int? offset = null,
        [AliasAs("limit")] int? limit = null,
        [AliasAs("with_session")] bool? withSession = null,
        [AliasAs("mature_content")] bool? matureContent = null);
    
    [Post("/api/v1/oauth2/collections/folders/create")]
    Task<Folder> CreateCollection([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> data);
    
    [Get("/api/v1/oauth2/collections/all")]
    Task<PaginatedBase<Deviation>> GetFromAllCollections([AliasAs("username")]string? username,
        [AliasAs("offset")] int? offset = null,
        [AliasAs("limit")] int? limit = null,
        [AliasAs("with_session")] bool? withSession = null,
        [AliasAs("mature_content")] bool? matureContent = null);
    
    [Get("/api/v1/oauth2/collections/folders")]
    Task<PaginatedBase<CollectionFolder>> GetAllCollections([AliasAs("username")]string? username,
        [AliasAs("calculate_size")] bool? calculateSize,
        [AliasAs("ext_preload")] bool? extPreload,
        [AliasAs("filter_empty_folder")] bool? filterEmptyFolder,
        [AliasAs("offset")] int? offset = null,
        [AliasAs("limit")] int? limit = null,
        [AliasAs("with_session")] bool? withSession = null,
        [AliasAs("mature_content")] bool? matureContent = null);
    
    [Post("/api/v1/oauth2/collections/fave")]
    Task<SimpleResponseBase> AddDeviationsToFavourites([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> request);
    
    [Post("/api/v1/oauth2/collections/folders/copy_deviations")]
    Task<SimpleResponseBase> CopyDeviationsToCollection([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> request);
    
    [Post("/api/v1/oauth2/collections/folders/move_deviations")]
    Task<SimpleResponseBase> MoveDeviationsToCollection([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> request);
    
    [Get("/api/v1/oauth2/collections/folders/remove/{folderId}")]
    Task<SimpleResponseBase> RemoveCollection(Guid folderId);
    
    [Post("/api/v1/oauth2/collections/folders/remove_deviations")]
    Task<SimpleResponseBase> RemoveDeviationsFromCollection([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> request);
    
    [Post("/api/v1/oauth2/collections/folders/update")]
    Task<SimpleResponseBase> UpdateCollection([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> request);
    
    [Post("/api/v1/oauth2/collections/folders/update_deviation_order")]
    Task<SimpleResponseBase> UpdateDeviationOrderCollection([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> request);

    [Post("/api/v1/oauth2/collections/folders/update_order")]
    Task<SimpleResponseBase> UpdateOrderCollection([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> request);
    
    [Post("/api/v1/oauth2/collections/unfave")]
    Task<SimpleResponseBase> RemoveDeviationsFromFavourites([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> request);
}