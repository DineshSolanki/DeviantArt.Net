using System.Text.Json;
using DeviantArt.Net.Models.Stash;

namespace DeviantArt.Net.Api;

public partial class Client
{
    
    //Publish a Sta.sh item to deviantART 
    public async Task<PublishStashResponse> PublishStashAsync(PublishStashRequest request)
    {
        var json = JsonSerializer.Serialize(request);
        Console.WriteLine($"Serialized Request: {json}");
        return await _api.PublishStashAsync(request);
    }
}