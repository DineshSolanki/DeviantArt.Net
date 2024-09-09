using DeviantArt.Net.Models.Deviation;

namespace DeviantArt.Net.Api;

internal partial interface IDeviantArtApi
{
    [Get("/api/v1/oauth2/deviation/{deviationId}")]
    Task<Deviation> GetDeviationAsync(Guid deviationId);
    
    [Get("/api/v1/oauth2/deviation/content")]
    Task<DeviationContent> GetDeviationContentAsync([AliasAs("deviationid")] Guid deviationId);
    
    [Get("/api/v1/oauth2/deviation/download/{deviationId}")]
    Task<DeviationDownloadMetadata> DownloadDeviationAsync(Guid deviationId);
    
    [Post("/api/v1/oauth2/deviation/edit/{deviationId}")]
    Task<DeviationChangeResponse> EditDeviationAsync(Guid deviationId,
        [Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> request);

    [Post("/api/v1/oauth2/deviation/journal/create")]
    Task<DeviationCreationResponse> CreateJournalAsync([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> request);
    
    [Post("/api/v1/oauth2/deviation/journal/update/{deviationId}")]
    Task<DeviationChangeResponse> UpdateJournalAsync(Guid deviationId, [Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> request);
    
    [Post("/api/v1/oauth2/deviation/literature/create")]
    Task<DeviationCreationResponse> CreateLiteratureAsync([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> request);
    
    [Post("/api/v1/oauth2/deviation/literature/update/{deviationid}")]
    Task<DeviationChangeResponse> UpdateLiteratureAsync(Guid deviationId, [Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> request);
    
    [Post("/api/v1/oauth2/deviation/metadata")]
    Task<DeviationMetadataResponse> GetDeviationMetadataAsync([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> request);
    
    [Get("/api/v1/oauth2/deviation/whofaved")]
    Task<PaginatedBase<FavouritedBy>> GetWhoFavedAsync([AliasAs("deviationid")] Guid deviationId,
        [AliasAs("offset")] int? offset = null,
        [AliasAs("limit")] int? limit = null);
    
}