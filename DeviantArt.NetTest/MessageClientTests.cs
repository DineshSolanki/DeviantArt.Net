namespace DeviantArt.NetTest;

[TestClass]
public class MessageClientTests : Testbase
{
    [TestMethod]
    public async Task DeleteMessageAsyncTest()
    {
        try
        {
            var response = await Client.DeleteMessageAsync(folderId:Ids.FolderId);
            Console.WriteLine(response);
        }
        catch (DeviantArtApiException e)
        {
            Console.WriteLine(e.ErrorResponse);
            Assert.IsTrue(e.ErrorResponse?.ErrorType == "invalid_request");
        }
    }

    [TestMethod]
    public async Task GetFeedAsyncTest()
    {
        try
        {
            var response = await Client.GetFeedAsync(folderId: Ids.FolderId);
        }
        catch (DeviantArtApiException e)
        {
            Console.WriteLine(e.ErrorResponse);
            Assert.IsTrue(e.ErrorResponse?.ErrorType == "invalid_request");
        }
    }
    
    [TestMethod]
    public async Task GetFeedbackAsyncTest()
    {
        try
        {
            var response = await Client.GetFeedbackAsync(FeedbackMessageType.Activity, folderId: Ids.FolderId);
            Console.WriteLine(response);
        }
        catch (DeviantArtApiException e)
        {
            Console.WriteLine(e.ErrorResponse);
            Assert.IsTrue(e.ErrorResponse?.ErrorType == "invalid_request");
        }
    }
    
    [TestMethod]
    public async Task GetFeedbackStackAsyncTest()
    {
        try
        {
            var response = await Client.GetFeedbackStackAsync(Ids.FolderId);
            Console.WriteLine(response);
        }
        catch (DeviantArtApiException e)
        {
            Console.WriteLine(e.ErrorResponse);
            Assert.IsTrue(e.ErrorResponse?.ErrorType == "invalid_request");
        }
    }
    
    [TestMethod]
    public async Task GetMentionsAsyncTest()
    {
        try
        {
            var response = await Client.GetMentionsAsync(folderId: Ids.FolderId);
            Console.WriteLine(response);
        }
        catch (DeviantArtApiException e)
        {
            Console.WriteLine(e.ErrorResponse);
            Assert.IsTrue(e.ErrorResponse?.ErrorType == "invalid_request");
        }
    }
    
    [TestMethod]
    public async Task GetMentionsStackAsyncTest()
    {
        try
        {
            var response = await Client.GetMentionsStackAsync(Ids.FolderId);
            Console.WriteLine(response);
        }
        catch (DeviantArtApiException e)
        {
            Console.WriteLine(e.ErrorResponse);
            Assert.IsTrue(e.ErrorResponse?.ErrorType == "invalid_request");
        }
    }
}