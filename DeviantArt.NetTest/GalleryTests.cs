using DeviantArt.Net.Models.Deviation;

namespace DeviantArt.NetTest;

[TestClass]
public class GalleryTests : Testbase
{
    
    [TestMethod]
    public async Task GetGalleryFoldersAsyncTest()
    {
        var response = await Client.GetGalleryFoldersAsync();
        Assert.IsTrue(response.Results.Count > 0); // There will be at least one folder (Featured)
    }
    
    [TestMethod]
    public async Task GetGalleryFolderAsyncTest()
    {
        var response = await Client.GetGalleryFolderAsync(username:Ids.JacksMafiaUsername, sortBy:Sort.Newest);
        Assert.IsTrue(response.Results.Count > 0); // There will be at least one deviation
    }
    
    [TestMethod]
    public async Task GetAllGalleryFoldersAsyncTest()
    {
        var response = await Client.GetAllGalleryFoldersAsync(username:Ids.JacksMafiaUsername);
        Assert.IsTrue(response.Results.Count > 0);
    }
    
    [TestMethod]
    public async Task CopyDeviationsAsyncTest()
    {
        var targetFolderId = Guid.Parse("1187871F-8F46-A674-8374-992CED771E68");
        var deviationIds = new List<Guid> { Guid.Parse("1187871F-8F46-A674-8374-992CED771E68"),Guid.Parse("1187871F-8F46-A674-8374-992CED771E68") };
        var request = new CopyDeviationsRequest
        {
            TargetFolderId = targetFolderId,
            DeviationIds = deviationIds
        };
        var response = await Client.CopyDeviationsAsync(request);
        Assert.IsTrue(response.Success);
    }

    [TestMethod]
    public async Task MoveDeviationsAsyncTest()
    {
        var targetFolderId = Guid.Parse("1187871F-8F46-A674-8374-992CED771E68");
        var sourceFolderId = Guid.Parse("1187871F-8F46-A674-8374-992CED771E68");
        var deviationIds = new List<Guid> { Guid.Parse("1187871F-8F46-A674-8374-992CED771E68"),Guid.Parse("1187871F-8F46-A674-8374-992CED771E68") };
        var request = new MoveDeviationsRequest()
        {
            SourceFolderId = sourceFolderId,
            TargetFolderId = targetFolderId,
            DeviationIds = deviationIds
        };
        var response = await Client.MoveDeviationsAsync(request);
        Assert.IsTrue(response.Success);
    }

    [TestMethod]
    public async Task RemoveDeviationsFromGallery()
    {
        var deviationIds = new List<Guid> { Guid.Parse("1187871F-8F46-A674-8374-992CED771E68"),Guid.Parse("1187871F-8F46-A674-8374-992CED771E68") };
        var folderId = Guid.Parse("1187871F-8F46-A674-8374-992CED771E68");
        var response = await Client.RemoveDeviationsFromGalleryAsync(folderId, deviationIds);
        Assert.IsTrue(response.Success);
    }
    
    [TestMethod]
    public async Task CreateGalleryFolderAsyncTest()
    {
        var response = await Client.CreateGalleryFolderAsync("TestFolder","TestDescription");
        Assert.IsNotNull(response.FolderId);
    }
    
    [TestMethod]
    public async Task DeleteFolderAsyncTest()
    {
        var folderId = Guid.Parse("1187871F-8F46-A674-8374-992CED771E68");
        var response = await Client.DeleteFolderAsync(folderId);
        Assert.IsTrue(response.Success);
    }
    
    [TestMethod]
    public async Task MoveFolderAsyncTest()
    {
        var folderId = Guid.Parse("1187871F-8F46-A674-8374-992CED771E68");
        var newParentId = Guid.Parse("1187871F-8F46-A674-8374-992CED771E68");
        var response = await Client.MoveFolderAsync(folderId, newParentId);
        Assert.IsTrue(response.Success);
    }
    
    [TestMethod]
    public async Task UpdateFolderAsyncTest()
    {
        var folderId = Guid.Parse("1187871F-8F46-A674-8374-992CED771E68");
        var response = await Client.UpdateFolderAsync(folderId, "NewName");
        Assert.IsTrue(response.Success);
    }
    
    [TestMethod]
    public async Task UpdateDeviationOrderAsyncTest()
    {
        var folderId = Guid.Parse("1187871F-8F46-A674-8374-992CED771E68");
        var deviationId = Guid.Parse("1187871F-8F46-A674-8374-992CED771E68");
        var response = await Client.UpdateDeviationOrderAsync(folderId, deviationId, 1);
        Assert.IsTrue(response.Success);
    }
    
    [TestMethod]
    public async Task UpdateFolderOrderAsyncTest()
    {
        var folderId = Guid.Parse("1187871F-8F46-A674-8374-992CED771E68");
        var response = await Client.UpdateFolderOrderAsync(folderId,1);
        Assert.IsTrue(response.Success);
    }
}