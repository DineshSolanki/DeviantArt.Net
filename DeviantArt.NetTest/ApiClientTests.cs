namespace DeviantArt.NetTest;

[TestClass]
public class ClientTests
{
    private readonly Client _client = Util.GetClientByGrantType(GrantType.ClientCredentials);


    [TestInitialize]
    public void Setup()
    {
           
    }

    [TestMethod]
    public async Task isTokenValidAsync_ShouldReturnPlaceboResponse()
    {
            
        var expectedResponse = Util.LoadJsonFromFile<PlaceboResponse>("ExpectedResponses/Auth/PlaceboResponse.json");
            
        var result = await _client.IsTokenValidAsync();
            
        Assert.AreEqual(expectedResponse.Status, result.Status);
    }

    [TestMethod]
    public async Task GetDeviationAsync_ShouldReturnDeviation()
    {
        var expectedDeviation = Util.LoadJsonFromFile<Deviation>("ExpectedResponses/Deviations/Deviation.json");
            
        var result = await _client.GetDeviationAsync(Ids.PoolByAllRich);
            
        Assert.AreEqual(expectedDeviation.DeviationId, result.DeviationId);
    }
}