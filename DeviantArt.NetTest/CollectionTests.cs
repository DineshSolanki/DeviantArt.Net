using DeviantArt.Net.Models.Deviation;

namespace DeviantArt.NetTest;

[TestClass]
public class CollectionTests : Testbase
{
    
    [TestMethod]
    public async Task GetCollection()
    {
        var folderId = Guid.Parse("8bc3907e-53bc-d153-8a56-37f7a32889d7");
        var result = await Client.GetCollectionAsync(folderId);
        Assert.IsNotNull(result);
    }
    
    [TestMethod]
    public async Task CreateCollection()
    {
        const string collectionName = "Test";
        var result = await Client.CreateCollectionAsync(collectionName);
        Assert.IsNotNull(result.FolderId);
    }
    
    [TestMethod]
    public async Task GetFromAllCollections()
    {
        var result = await Client.GetFromAllCollectionsAsync();
        Assert.IsNotNull(result);
    }
    
    [TestMethod]
    public async Task GetAllCollections()
    {
        var result = await Client.GetAllCollectionsAsync();
        Assert.IsNotNull(result);
    }
    
    [TestMethod]
    public async Task AddDeviationsToFavourites()
    {
        var deviationId = Guid.Parse("8bc3907e-53bc-d153-8a56-37f7a32889d7");
        var result = await Client.AddDeviationsToFavouritesAsync(deviationId);
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task CopyDeviationsToCollection()
    {
        var copyDeviationsRequest = new CopyDeviationsRequest
        {
            TargetFolderId = Guid.Parse("8bc3907e-53bc-d153-8a56-37f7a32889d7"),
            DeviationIds = [Guid.Parse("8bc3907e-53bc-d153-8a56-37f7a32889d7")]
        };
        var result = await Client.CopyDeviationsToCollectionAsync(copyDeviationsRequest);
        Assert.IsNotNull(result);
    }
    
    [TestMethod]
    public async Task MoveDeviationsToCollection()
    {
        var moveDeviationsRequest = new MoveDeviationsRequest
        {
            SourceFolderId = Guid.Parse("8bc3907e-53bc-d153-8a56-37f7a32889d7"),
            TargetFolderId = Guid.Parse("8bc3907e-53bc-d153-8a56-37f7a32889d7"),
            DeviationIds = [Guid.Parse("8bc3907e-53bc-d153-8a56-37f7a32889d7")]
        };
        var result = await Client.MoveDeviationsToCollectionAsync(moveDeviationsRequest);
        Assert.IsNotNull(result);
    }
    
    [TestMethod]
    public async Task RemoveCollection()
    {
        var folderId = Guid.Parse("8bc3907e-53bc-d153-8a56-37f7a32889d7");
        var result = await Client.RemoveCollectionAsync(folderId);
        Assert.IsNotNull(result);
    }
    
    [TestMethod]
    public async Task RemoveDeviationsFromCollection()
    {
        var folderId = Guid.Parse("8bc3907e-53bc-d153-8a56-37f7a32889d7");
        List<Guid> deviationIds = [Guid.Parse("8bc3907e-53bc-d153-8a56-37f7a32889d7")];
        var result = await Client.RemoveDeviationsFromCollectionAsync(folderId, deviationIds);
        Assert.IsNotNull(result);
    }
    
    [TestMethod]
    public async Task UpdateCollection()
    {
        var folderId = Guid.Parse("8bc3907e-53bc-d153-8a56-37f7a32889d7");
        const string collectionName = "Test";
        var result = await Client.UpdateCollectionAsync(folderId, collectionName);
        Assert.IsNotNull(result);
    }
    
    [TestMethod]
    public async Task UpdateDeviationOrderCollection()
    {
        var folderId = Guid.Parse("8bc3907e-53bc-d153-8a56-37f7a32889d7");
        var deviationId = Guid.Parse("8bc3907e-53bc-d153-8a56-37f7a32889d7");
        var result = await Client.UpdateDeviationOrderCollectionAsync(folderId, deviationId, 1);
        Assert.IsNotNull(result);
    }
    
    [TestMethod]
    public async Task UpdateFolderOrderCollection()
    {
        var folderId = Guid.Parse("8bc3907e-53bc-d153-8a56-37f7a32889d7");
        var result = await Client.UpdateCollectionOrderAsync(folderId,1);
        Assert.IsNotNull(result);
    }
    
    [TestMethod]
    public async Task RemoveDeviationsFromFavourites()
    {
        var deviationId = Guid.Parse("8bc3907e-53bc-d153-8a56-37f7a32889d7");
        var result = await Client.RemoveDeviationsFromFavouritesAsync(deviationId);
        Assert.IsNotNull(result);
    }
}