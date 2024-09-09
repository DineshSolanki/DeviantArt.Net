namespace DeviantArt.NetTest;

[TestClass]
public class CommentsTests : Testbase
{
    
    [TestMethod]
    public async Task GetCommentsAsyncTest()
    {
        var comments = await Client.GetCommentSiblingsAsync(new Guid(Ids.JacksMafiaWweArtCommentIdOfKingOfDeath));
        Assert.IsNotNull(comments);
        Assert.IsTrue(comments.Thread.Count > 0);
        Assert.IsTrue(comments.Thread.First().Posted == Ids.JacksMafiaWweArtCommentDateOfKingOfDeath);
    }
    
    [TestMethod]
    public async Task GetDeviationCommentsAsyncTest()
    {
        var comments = await Client.GetDeviationCommentsAsync(Ids.JacksMafiaWweArtDeviationId);
        Assert.IsNotNull(comments);
        Assert.IsTrue(comments.Thread.Count > 0);
        Assert.IsTrue(comments.Thread.First().Posted == Ids.JacksMafiaWweArtCommentDateOfKingOfDeath);
    }
    
    [TestMethod]
    public async Task PostCommentOnDeviationTest()
    {
        var comment = await Client.PostCommentOnDeviation(Ids.JacksMafiaWweArtDeviationId, "Test comment");
        Assert.IsNotNull(comment);
        Assert.IsTrue(comment.Posted <= DateTime.Now);
    }
    
    [TestMethod]
    public async Task PostCommentOnProfileTest()
    {
        var comment = await Client.PostCommentOnProfile(Ids.JacksMafiaUsername, "Test comment");
        Assert.IsNotNull(comment);
        Assert.IsTrue(comment.Posted <= DateTime.Now);
    }
    
    [TestMethod]
    public async Task PostCommentOnStatusTest()
    {
        var comment = await Client.PostCommentOnStatus(Ids.JacksMafiaWweArtDeviationId, "Test comment");
        Assert.IsNotNull(comment);
        Assert.IsTrue(comment.Posted <= DateTime.Now);
    }
    
    [TestMethod]
    public async Task GetProfileCommentsAsyncTest()
    {
        var comments = await Client.GetProfileCommentsAsync(Ids.JacksMafiaUsername);
        Assert.IsNotNull(comments);
        Assert.IsTrue(comments.Thread.Count > 0);
    }
    
    [TestMethod]
    public async Task GetStatusCommentsAsyncTest()
    {
        var comments = await Client.GetStatusCommentsAsync(Ids.JacksMafiaWweArtDeviationId);
        Assert.IsNotNull(comments);
        Assert.IsTrue(comments.Thread.Count > 0);
    }
}