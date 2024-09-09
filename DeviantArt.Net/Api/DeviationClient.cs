using DeviantArt.Net.Models.Deviation;
using DeviantArt.Net.Modules;

namespace DeviantArt.Net.Api;

/// <summary>
/// Client class for interacting with DeviantArt API to manage deviations, journals, and literature.
/// </summary>
public partial class Client
{
    /// <summary>
    /// Retrieves a deviation by its ID.
    /// </summary>
    /// <param name="deviationId">The ID of the deviation to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the deviation.</returns>
    public async Task<Deviation> GetDeviationAsync(Guid deviationId)
    {
        return await _api.GetDeviationAsync(deviationId);
    }

    /// <summary>
    /// Retrieves a deviation by its object.
    /// </summary>
    /// <param name="deviation">The deviation object containing the ID.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the deviation.</returns>
    public async Task<Deviation> GetDeviationAsync(Deviation deviation)
    {
        return await GetDeviationAsync(deviation.DeviationId);
    }

    /// <summary>
    /// Fetches full content data for a deviation, including custom CSS rules and fonts.
    /// </summary>
    /// <param name="deviationId">The ID of the deviation to fetch content for.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the deviation content.</returns>
    public async Task<DeviationContent> GetDeviationContentAsync(Guid deviationId)
    {
        return await _api.GetDeviationContentAsync(deviationId);
    }

    /// <summary>
    /// Retrieves metadata for downloading a deviation.
    /// </summary>
    /// <param name="deviationId">The ID of the deviation to download.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the download metadata.</returns>
    public async Task<DeviationDownloadMetadata> DownloadDeviationAsync(Guid deviationId)
    {
        return await _api.DownloadDeviationAsync(deviationId);
    }

    /// <summary>
    /// Edits a deviation. Null or empty values will clear the corresponding fields.
    /// </summary>
    /// <param name="deviationUpdateRequest">The request object containing the updated deviation data.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the response of the edit operation.</returns>
    public async Task<DeviationChangeResponse> EditDeviationAsync(DeviationUpdateRequest deviationUpdateRequest)
    {
        var request = new Dictionary<string, object> { { "title", deviationUpdateRequest.Title } };
        request.AddIfNotNull("is_mature", deviationUpdateRequest.IsMature);
        request.AddIfNotNull("mature_level", deviationUpdateRequest.MatureLevel?.GetDescription());
        request.AddEnumArray("mature_classification", deviationUpdateRequest.MatureClassification);
        request.AddIfNotNull("allow_comments", deviationUpdateRequest.AllowComments);
        request.AddIfNotNull("galleryids", deviationUpdateRequest.GalleryIds);
        request.AddIfNotNull("allow_free_download", deviationUpdateRequest.AllowFreeDownload);
        request.AddIfNotNull("add_watermark", deviationUpdateRequest.AddWatermark);

        request.AddEnumerable("tags", deviationUpdateRequest.Tags);

        request.AddIfNotNull("license_options[creative_commons]", deviationUpdateRequest.LicenseOptions?.CreativeCommons);
        request.AddIfNotNull("license_options[modify]", deviationUpdateRequest.LicenseOptions?.Modify.GetDescription());
        request.AddIfNotNull("license_options[commercial]", deviationUpdateRequest.LicenseOptions?.Commercial);

        return await _api.EditDeviationAsync(deviationUpdateRequest.DeviationId, request);
    }

    /// <summary>
    /// Creates a new journal.
    /// </summary>
    /// <param name="journalCreationRequest">The request object containing the journal data.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the ID of the created journal.</returns>
    public async Task<Guid> CreateJournalAsync(journalCreationRequest journalCreationRequest)
    {
        var request = new Dictionary<string, object> { { "title", journalCreationRequest.Title } };
        request.AddIfNotNull("body", journalCreationRequest.Body);

        request.AddEnumerable("tags", journalCreationRequest.Tags);

        request.AddIfNotNull("cover_image_deviation_id", journalCreationRequest.CoverImageDeviationId);
        request.AddIfNotNull("embedded_image_deviation_id", journalCreationRequest.EmbeddedDeviationId);
        request.AddIfNotNull("is_mature", journalCreationRequest.IsMature);
        request.AddIfNotNull("allow_comments", journalCreationRequest.AllowComments);

        request.AddIfNotNull("license_options[creative_commons]", journalCreationRequest.LicenseOptions?.CreativeCommons);
        request.AddIfNotNull("license_options[modify]", journalCreationRequest.LicenseOptions?.Modify.GetDescription());
        request.AddIfNotNull("license_options[commercial]", journalCreationRequest.LicenseOptions?.Commercial);
        var response = await _api.CreateJournalAsync(request);
        return response.DeviationId;
    }

    /// <summary>
    /// Updates an existing journal. Empty values will clear the corresponding fields.
    /// </summary>
    /// <param name="journalUpdateRequest">The request object containing the updated journal data.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the response of the update operation.</returns>
    public async Task<DeviationChangeResponse> UpdateJournalAsync(JournalUpdateRequest journalUpdateRequest)
    {
        var request = new Dictionary<string, object> { { "title", journalUpdateRequest.Title } };

        journalUpdateRequest.Tags?.Select((tag, index) => new { tag, index })
            .ToList()
            .ForEach(t => request.Add($"tags[{t.index}]", t.tag));

        request.AddIfNotNull("cover_image_deviation_id", journalUpdateRequest.CoverImageDeviationId);
        request.AddIfNotNull("reset_cover_image_deviation_id", journalUpdateRequest.ResetCoverImage);
        request.AddIfNotNull("is_mature", journalUpdateRequest.IsMature);
        request.AddIfNotNull("allow_comments", journalUpdateRequest.AllowComments);

        request.AddIfNotNull("license_options[creative_commons]", journalUpdateRequest.LicenseOptions?.CreativeCommons);
        request.AddIfNotNull("license_options[modify]", journalUpdateRequest.LicenseOptions?.Modify.GetDescription());
        request.AddIfNotNull("license_options[commercial]", journalUpdateRequest.LicenseOptions?.Commercial);

        return await _api.UpdateJournalAsync(journalUpdateRequest.DeviationId, request);
    }

    /// <summary>
    /// Creates a new literature deviation.
    /// </summary>
    /// <param name="literatureCreationRequest">The request object containing the literature data.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the ID of the created literature.</returns>
    public async Task<Guid> CreateLiteratureAsync(LiteratureCreationRequest literatureCreationRequest)
    {
        var request = new Dictionary<string, object> { { "title", literatureCreationRequest.Title } };
        request.AddIfNotNull("body", literatureCreationRequest.Body);
        request.AddIfNotNull("description", literatureCreationRequest.Description);

        request.AddEnumerable("tags", literatureCreationRequest.Tags);

        request.AddIfNotNull("galleryids", literatureCreationRequest.GalleryIds);
        request.AddIfNotNull("is_mature", literatureCreationRequest.IsMature);
        request.AddIfNotNull("mature_level", literatureCreationRequest.MatureLevel?.GetDescription());
        request.AddEnumArray("mature_classification", literatureCreationRequest.MatureClassification);
        request.AddIfNotNull("allow_comments", literatureCreationRequest.AllowComments);

        request.AddIfNotNull("license_options[creative_commons]", literatureCreationRequest.LicenseOptions?.CreativeCommons);
        request.AddIfNotNull("license_options[modify]", literatureCreationRequest.LicenseOptions?.Modify.GetDescription());
        request.AddIfNotNull("license_options[commercial]", literatureCreationRequest.LicenseOptions?.Commercial);

        request.AddIfNotNull("embedded_image_deviation_id", literatureCreationRequest.EmbeddedDeviationId);
        var response = await _api.CreateLiteratureAsync(request);
        return response.DeviationId;
    }

    /// <summary>
    /// Updates an existing literature deviation. Empty values will clear the corresponding fields.
    /// </summary>
    /// <param name="literatureUpdateRequest">The request object containing the updated literature data.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the response of the update operation.</returns>
    public async Task<DeviationChangeResponse> UpdateLiteratureAsync(LiteratureUpdateRequest literatureUpdateRequest)
    {
        var request = new Dictionary<string, object> { { "title", literatureUpdateRequest.Title } };

        request.AddEnumerable("tags", literatureUpdateRequest.Tags);

        request.AddIfNotNull("galleryids", literatureUpdateRequest.GalleryIds);
        request.AddIfNotNull("is_mature", literatureUpdateRequest.IsMature);
        request.AddIfNotNull("mature_level", literatureUpdateRequest.MatureLevel?.GetDescription());
        request.AddEnumArray("mature_classification", literatureUpdateRequest.MatureClassification);
        request.AddIfNotNull("allow_comments", literatureUpdateRequest.AllowComments);

        request.AddIfNotNull("license_options[creative_commons]", literatureUpdateRequest.LicenseOptions?.CreativeCommons);
        request.AddIfNotNull("license_options[modify]", literatureUpdateRequest.LicenseOptions?.Modify.GetDescription());
        request.AddIfNotNull("license_options[commercial]", literatureUpdateRequest.LicenseOptions?.Commercial);

        return await _api.UpdateLiteratureAsync(literatureUpdateRequest.DeviationId, request);
    }

    /// <summary>
    /// Fetches metadata for a set of deviations. Limited to 50 deviations per query for base data and 10 for extended data.
    /// </summary>
    /// <param name="deviationMetadataRequest">The request object containing the deviation IDs and optional extended data flags.</param>
    /// <param name="withSession">Optional flag to include session data.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the metadata response.</returns>
    public async Task<DeviationMetadataResponse> GetDeviationMetadataAsync(DeviationMetadataRequest deviationMetadataRequest, bool? withSession = null)
    {
        var request = new Dictionary<string, object>();
        if (withSession != null)
        {
            request.Add("with_session", withSession);
        }
        request.AddEnumerable("deviationids", deviationMetadataRequest.DeviationIds);
        request.AddIfNotNull("ext_submission", deviationMetadataRequest.ExtSubmission);
        request.AddIfNotNull("ext_camera", deviationMetadataRequest.ExtCamera);
        request.AddIfNotNull("ext_stats", deviationMetadataRequest.ExtStats);
        request.AddIfNotNull("ext_collections", deviationMetadataRequest.ExtCollection);
        request.AddIfNotNull("ext_galleries", deviationMetadataRequest.ExtGalleries);

        return await _api.GetDeviationMetadataAsync(request);
    }

    /// <summary>
    /// Retrieves a list of users who have favorited a deviation. The list is not sorted in any specific order.
    /// </summary>
    /// <param name="deviationId">The ID of the deviation.</param>
    /// <param name="offset">Optional offset for pagination.</param>
    /// <param name="limit">Optional limit for pagination.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a paginated list of users who favorited the deviation.</returns>
    public async Task<PaginatedBase<FavouritedBy>> GetWhoFavedAsync(Guid deviationId, int? offset = null, int? limit = null)
    {
        return await _api.GetWhoFavedAsync(deviationId, offset, limit);
    }
}