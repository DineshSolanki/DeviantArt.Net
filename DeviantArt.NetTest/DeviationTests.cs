namespace DeviantArt.NetTest;

[TestClass]
public class DeviationTests : Testbase
{
    private Guid _journalDeviationId;
    private Guid _literatureDeviationId;
    
    [TestMethod]
    public async Task GetDeviationAsync()
    {
        var deviation = await Client.GetDeviationAsync(Ids.JacksMafiaWweArtDeviationId);
        Assert.AreEqual(Ids.JacksMafiaUsername, deviation.Author.Username);
    }
    
    [TestMethod]
    public async Task GetDeviationContentAsync()
    {
        var deviationContent =
            await Client.GetDeviationContentAsync(Ids.JournalDeviationId);
        Assert.IsNotNull(deviationContent);
    }
    
    [TestMethod]
    public async Task DownloadDeviationAsync()
    {
        var deviationMetadata = await Client.DownloadDeviationAsync(Ids.JacksMafiaWweArtDeviationId);
        Assert.IsNotNull(deviationMetadata);
    }
    
    [TestMethod]
    public async Task EditDeviationAsync()
    {
        var deviationUpdateRequest = new DeviationUpdateRequest
        {
            DeviationId = new Guid("D084360F-AB2E-390D-7F81-56C7C3365BC3"),
            Title = "Test Deviation Updated",
            Tags = ["test","again"],
            MatureLevel = MatureLevel.Strict,
            IsMature = true,
            MatureClassification = [MatureClassification.Sexual, MatureClassification.Gore],
            LicenseOptions = new LicenseOption
            {
                CreativeCommons = true,
                Modify = LicenseOptionsModify.Share,
                Commercial = true
            }
        };
        
        var updateResponse = await Client.EditDeviationAsync(deviationUpdateRequest);
        Assert.IsNotNull(updateResponse.Status == "success");
    }
    
    [TestMethod]
    public async Task CreateJournalAsync()
    {
        var journalCreationRequest = new journalCreationRequest
        {
            Title = "Test Journal",
            Body = "This is a test journal",
            LicenseOptions = new LicenseOption
            {
                CreativeCommons = true,
                Modify = LicenseOptionsModify.Share,
                Commercial = true
            }
        };
        
        _journalDeviationId = await Client.CreateJournalAsync(journalCreationRequest);
        Assert.IsNotNull(_journalDeviationId);
    }
    
    [TestMethod]
    public async Task UpdateJournalAsync()
    {
        var journalUpdateRequest = new JournalUpdateRequest
        {
            DeviationId = _journalDeviationId,
            Title = "Test Journal Updated",
            Tags = ["test","again"],
            CoverImageDeviationId = Ids.JacksMafiaWweArtDeviationId,
            ResetCoverImage = false
        };
        
        var updateResponse = await Client.UpdateJournalAsync(journalUpdateRequest);
        Assert.IsNotNull(updateResponse.Status == "success");
    }
    
    [TestMethod]
    public async Task CreateLiteratureAsync()
    {
        var literatureCreationRequest = new LiteratureCreationRequest
        {
            Title = "Test Literature",
            Body = "This is a test literature",
            LicenseOptions = new LicenseOption
            {
                CreativeCommons = true,
                Modify = LicenseOptionsModify.Share,
                Commercial = true
            }
        };
        
        _literatureDeviationId = await Client.CreateLiteratureAsync(literatureCreationRequest);
        Assert.IsNotNull(_literatureDeviationId);
    }
    
    [TestMethod]
    public async Task UpdateLiteratureAsync()
    {
        var literatureUpdateRequest = new LiteratureUpdateRequest
        {
            DeviationId = _literatureDeviationId,
            Title = "Test Literature Updated",
            Tags = ["test","again"]
        };
        
        var updateResponse = await Client.UpdateLiteratureAsync(literatureUpdateRequest);
        Assert.IsNotNull(updateResponse.Status == "success");
    }
    
    [TestMethod]
    public async Task GetDeviationMetadataAsync()
    {
        var request = new DeviationMetadataRequest
        {
            DeviationIds = [Ids.JacksMafiaWweArtDeviationId]
        };
        var metadata = await Client.GetDeviationMetadataAsync(request);
        Assert.IsNotNull(metadata);
    }
    
    [TestMethod]
    public async Task GetWhoFavedAsync()
    {
        var whoFaved = await Client.GetWhoFavedAsync(Ids.JacksMafiaWweArtDeviationId);
        Assert.IsNotNull(whoFaved);
    }
}