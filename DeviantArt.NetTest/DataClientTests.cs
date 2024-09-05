namespace DeviantArt.NetTest;

[TestClass]
public class DataClientTests : Testbase
{
    
    [TestMethod]
    public async Task GetDataCountriesAsync_ShouldReturnCountriesResponse()
    {
        var result = await Client.GetDataCountriesAsync();
        
        Assert.IsTrue(result.Results.Count >= 243);
    }
    
    [TestMethod]
    public async Task GetDataPrivacyPolicyAsync_ShouldReturnPrivacyResponse()
    {
        var result = await Client.GetDataPrivacyPolicyAsync();
        
        Assert.IsNotNull(result.Text);
    }
    
    [TestMethod]
    public async Task GetDataSubmissionPolicyAsync_ShouldReturnSubmissionResponse()
    {
        var result = await Client.GetDataSubmissionPolicyAsync();
        
        Assert.IsNotNull(result.Text);
    }
    
    [TestMethod]
    public async Task GetDataTermsOfServiceAsync_ShouldReturnTermsOfServiceResponse()
    {
        var result = await Client.GetDataTermsOfServiceAsync();
        
        Assert.IsNotNull(result.Text);
    }
}