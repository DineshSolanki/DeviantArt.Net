using System.Text.Json;

namespace DeviantArt.Net.Modules.TokenStore;


/// <summary>
/// A class that implements the ITokenStore interface to store and retrieve tokens in a JSON file.
/// </summary>
public sealed class JsonTokenStore : ITokenStore
{
    private readonly string _filePath;
    private const string FileName = "DeviantArtAccessToken.json";

    
    /// <summary>
    /// Initializes a new instance of the JsonTokenStore class.
    /// </summary>
    /// <param name="folderPath">The folder path where the JSON file will be stored.</param>
    /// <param name="fileName">The name of the JSON file with extension. Defaults to "DeviantArtAccessToken.json".</param>
    public JsonTokenStore(string folderPath , string fileName = FileName)
    {
        _filePath = Path.Combine(folderPath, fileName);
    }

    public JsonTokenStore() : this(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData))
    {
    }
    
    /// <summary>
    /// Stores the given token in a JSON file.
    /// </summary>
    /// <param name="token">The token to store.</param>
    /// <returns>The stored token.</returns>
    public async Task<DeviantArtAccessToken> StoreTokenAsync(DeviantArtAccessToken token)
    {
        var json = JsonSerializer.Serialize(token);
        await File.WriteAllTextAsync(_filePath, json);
        return token;
    }

    
    /// <summary>
    /// Retrieves the token from the JSON file.
    /// </summary>
    /// <returns>The retrieved token, or null if the file does not exist.</returns>
    public async Task<DeviantArtAccessToken?> GetTokenAsync()
    {
        if (!File.Exists(_filePath))
        {
            return null;
        }

        var json = await File.ReadAllTextAsync(_filePath);
        return JsonSerializer.Deserialize<DeviantArtAccessToken>(json);
    }
}