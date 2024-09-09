using DeviantArt.Net.Models.Deviation;

namespace DeviantArt.NetTest;

[TestClass]
public class ClientTests : Testbase
{
    
    [TestInitialize]
    public void Setup()
    {
           
    }

    [TestMethod]
    public async Task isTokenValidAsync_ShouldReturnPlaceboResponse()
    {
            
        var expectedResponse = Util.LoadJsonFromFile<PlaceboResponse>("ExpectedResponses/Auth/PlaceboResponse.json");
            
        var result = await Client.IsTokenValidAsync();
            
        Assert.AreEqual(expectedResponse.Status, result.Status);
    }

    [TestMethod]
    public async Task GetDeviationAsync_ShouldReturnDeviation()
    {
        var expectedDeviation = Util.LoadJsonFromFile<Deviation>("ExpectedResponses/Deviations/Deviation.json");
            
        var result = await Client.GetDeviationAsync(Ids.PoolByAllRich);
            
        Assert.AreEqual(expectedDeviation.DeviationId, result.DeviationId);
    }
}