using DeviantArt.Net.Models.Stash;

namespace DeviantArt.NetTest;

[TestClass]
public class StashClientTests : Testbase
{
    
    [TestMethod]
    public async Task PublishStashAsync_ShouldReturnStashResponse()
    {
        var request = new PublishStashRequest
        {
            ItemId = 78451,
            IsMature = true,
            MatureLevel = MatureLevel.Strict,
            MatureClassification = [MatureClassification.Nudity, MatureClassification.Gore],
            /*CatPath = "digitalart/drawings/abstract",
            Feature = true,
            AllowComments = false,
            RequestCritique = false,
            DisplayResolution = DisplayResolution.Px400,
            Sharing = SharingOptions.HideAndMembersOnly,
            LicenseOptions = new Dictionary<string, bool>
            {
                { "creative_commons", true },
                { "commercial", false },
                { "modify", LicenseOptionsModify.Share.ToString() == "share" }
            }*/
        };
        var result = await Client.PublishStashAsync(request);
        
        Assert.IsNotNull(result.DeviationId);
    }
}