using DeviantArt.Net.Exceptions;

namespace DeviantArt.NetTest;

[TestClass]
public class MessageClientTests : Testbase
{
    [TestMethod]
    public async Task DeleteMessageAsyncTest()
    {
        try
        {
            var response = await Client.DeleteMessageAsync(folderId:"e5ed1544-6702-3085-877b-b63c6aa61c66");
            Console.WriteLine(response);
        }
        catch (DeviantArtApiException e)
        {
            Console.WriteLine(e.ErrorResponse);
            throw;
        }
    }

    [TestMethod]
    public async Task GetFeedAsyncTest()
    {
        var response = await Client.GetFeedAsync(folderId: "e5ed1544-6702-3085-877b-b63c6aa61c66");
    }
}