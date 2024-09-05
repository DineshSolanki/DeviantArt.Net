namespace DeviantArt.NetTest;

[TestClass]
public class BrowseTests : Testbase
{
    
    [TestMethod]
    public async Task GetDailyDeviationsAsync_ShouldReturnDeviantArtApiResponse()
    {
        var date = new DateOnly(2021, 10, 10);
        var result = await Client.GetDailyDeviationsAsync(date);
            
        Assert.IsNotNull(result);
    }
    
    [TestMethod]
    public async Task GetDeviantsYouWatchAsync_ShouldReturnDeviantArtApiResponse()
    {
            
        const int limit = 10;
        const int offset = 0;
            
        var result = await Client.GetDeviantsYouWatchAsync(offset, limit);
            
        Assert.IsFalse(result.Results.Count > 10);
    }
    
    [TestMethod]
    public async Task BrowseHomeDeviationsAsync_ShouldReturnDeviantArtApiResponse()
    {
            
        const int limit = 10;
        const int offset = 0;
        const bool matureContent = false;
            
        var result = await Client.BrowseHomeDeviationsAsync();
            
        Assert.IsFalse(result.Results.Count > 10);
    }

    [TestMethod]
    public async Task GetMoreLikeThisPreviewAsync_ShouldReturnSeededResponse()
    {
            
        var deviationId = Ids.PoolByAllRich;
            
        var result = await Client.GetMoreLikeThisPreviewAsync(deviationId);
            
        Assert.IsNotNull(result.Author);
    }
    
    [TestMethod]
    public async Task BrowseTagsAsync_ShouldReturnBrowseTagsResponse()
    {
        
        var expectedResponse = Util.LoadJsonFromFile<BrowseResponse>("ExpectedResponses/Browse/BrowseTags.json");
            
        var result = await Client.BrowseTagsAsync(Ids.tagName);
            
        Assert.AreEqual(expectedResponse.Results.Count, result.Results.Count);
    }
    
    [TestMethod]
    public async Task BrowseTagsSearchAsync_ShouldReturnTagNamesResponse()
    {
        
        var expectedResponse = Util.LoadJsonFromFile<TagNamesResponse>("ExpectedResponses/Browse/ArtTagNamesResponse.json");
            
        var result = await Client.BrowseTagsSearchAsync(Ids.tagName);
            
        Assert.AreEqual(expectedResponse.Results.Count, result.Results.Count);
    }
    
    [TestMethod]
    public async Task BrowseTopicAsync_ShouldReturnBrowseResponse()
    {
        
        var expectedResponse = Util.LoadJsonFromFile<BrowseResponse>("ExpectedResponses/Browse/ArtTopicBrowseResponse.json");
            
        var result = await Client.BrowseTopicAsync(Ids.tagName);
            
        Assert.AreEqual(expectedResponse.Results.Count, result.Results.Count);
    }
    
    [TestMethod]
    public async Task BrowseTopicsAsync_ShouldReturnTopicsResponse()
    {
        
        var result = await Client.BrowseTopicsAsync();
            
        Assert.IsNotNull( result.Results);
    }
    
    [TestMethod]
    public async Task BrowseTopTopicsAsync_ShouldReturnTopicsResponse()
    {
        
        var result = await Client.BrowseTopTopicsAsync();
            
        Assert.IsNotNull( result.Results);
    }
}