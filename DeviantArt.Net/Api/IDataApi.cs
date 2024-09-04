using DeviantArt.Net.Models.Data;

namespace DeviantArt.Net.Api;

internal partial interface IDeviantArtApi
{
    [Get("/api/v1/oauth2/data/countries")]
    Task<CountriesResponse> GetDataCountriesAsync(bool? matureContent = null);
    
    [Get("/api/v1/oauth2/data/privacy")]
    Task<PolicyResponse> GetDataPrivacyPolicyAsync(bool? matureContent = null);
    
    [Get("/api/v1/oauth2/data/submission")]
    Task<PolicyResponse> GetDataSubmissionPolicyAsync(bool? matureContent = null);
    
    [Get("/api/v1/oauth2/data/tos")]
    Task<PolicyResponse> GetDataTermsOfServiceAsync(bool? matureContent = null);
}