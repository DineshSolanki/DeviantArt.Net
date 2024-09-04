namespace DeviantArt.NetTest;

[TestClass]
public class DataClientTests
{
    private readonly Client _client = Util.GetClientByGrantType(GrantType.ClientCredentials);
    
    
    [TestMethod]
    public async Task GetDataCountriesAsync_ShouldReturnCountriesResponse()
    {
        var result = await _client.GetDataCountriesAsync();
        
        Assert.IsTrue(result.Results.Count >= 243);
    }
    
    [TestMethod]
    public async Task GetDataPrivacyPolicyAsync_ShouldReturnPrivacyResponse()
    {
        var result = await _client.GetDataPrivacyPolicyAsync();
        
        Assert.IsNotNull(result.Text);
    }
    
    [TestMethod]
    public async Task GetDataSubmissionPolicyAsync_ShouldReturnSubmissionResponse()
    {
        var result = await _client.GetDataSubmissionPolicyAsync();
        
        Assert.IsNotNull(result.Text);
    }
    
    [TestMethod]
    public async Task GetDataTermsOfServiceAsync_ShouldReturnTermsOfServiceResponse()
    {
        var result = await _client.GetDataTermsOfServiceAsync();
        
        Assert.IsNotNull(result.Text);
    }
}