namespace DeviantArt.Net.Api;

public partial class Client
{
    /// <summary>
    /// Asynchronously retrieves a list of countries.
    /// </summary>
    /// <param name="matureContent">Indicates whether to include mature content in the results.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the list of countries.</returns>
    public async Task<CountriesResponse> GetDataCountriesAsync(bool? matureContent = null)
    {
        return await _api.GetDataCountriesAsync(matureContent);
    }

    /// <summary>
    /// Asynchronously retrieves the DeviantArt Privacy Policy.
    /// </summary>
    /// <param name="matureContent">Indicates whether to include mature content in the results.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the DeviantArt Privacy Policy.</returns>
    public async Task<PolicyResponse> GetDataPrivacyPolicyAsync(bool? matureContent = null)
    {
        return await _api.GetDataPrivacyPolicyAsync(matureContent);
    }

    /// <summary>
    /// Asynchronously retrieves the DeviantArt Submission Policy.
    /// </summary>
    /// <param name="matureContent">Indicates whether to include mature content in the results.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the DeviantArt Submission Policy.</returns>
    public async Task<PolicyResponse> GetDataSubmissionPolicyAsync(bool? matureContent = null)
    {
        return await _api.GetDataSubmissionPolicyAsync(matureContent);
    }

    /// <summary>
    /// Asynchronously retrieves the DeviantArt Terms of Service.
    /// </summary>
    /// <param name="matureContent">Indicates whether to include mature content in the results.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the DeviantArt Terms of Service.</returns>
    public async Task<PolicyResponse> GetDataTermsOfServiceAsync(bool? matureContent = null)
    {
        return await _api.GetDataTermsOfServiceAsync(matureContent);
    }
}