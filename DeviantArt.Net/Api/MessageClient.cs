using DeviantArt.Net.Models.Message;

namespace DeviantArt.Net.Api;

public partial class Client
{
    
    //Delete a message or a message stack 
    public async Task<MessageResponseBase> DeleteMessageAsync(string? messageId = null, string? stackId = null, string? folderId = null)
    {
        var request = new MessageRequest
        {
            MessageId = messageId,
            StackId = stackId,
            FolderId = folderId
        };
        return await _api.DeleteMessageAsync(request);
    }
    /// <summary>
    ///  Get Feed of all messages
    ///  can be fetched in a stacked (default) or flat mode. In the stacked mode similar messages will be grouped together and the most recent one will be returned.
    /// stackid can be used to fetch the rest of the messages in the stack. 
    /// </summary>
    /// <param name="folderId">The folder to fetch messages from, defaults to inbox [must be valid UUID]</param>
    /// <param name="stackMode">True to use stacked mode, false to use flat mode</param>
    /// <param name="cursor">The cursor for pagination.</param>
    /// <param name="withSession">Indicates whether to include session information in the request.</param>
    /// <param name="matureContent">Indicates whether to include mature content in the results.</param>
    /// <returns></returns>
    public async Task<Message> GetFeedAsync(string? folderId = null, bool? stackMode = null, string? cursor = null, bool withSession = false, bool? matureContent = null)
    {
        return await _api.GetFeedAsync(folderId, stackMode, cursor, withSession, matureContent);
    }
    
    
}