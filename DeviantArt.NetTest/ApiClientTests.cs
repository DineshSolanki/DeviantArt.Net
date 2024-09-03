using System.Text.Json;
using DeviantArt.Net.Api;
using DeviantArt.Net.Client.Authentication;
using DeviantArt.Net.Models;
using DeviantArt.Net.Modules.Client.Authentication;
using DeviantArt.NetTest.Util;

namespace DeviantArt.NetTest
{
    [TestClass]
    public class AuthenticatedDeviantArtApiClientTests
    {
        private DeviantArtOAuthClient _oauthClient;
        private AuthenticatedDeviantArtApiClient _client;
        
        
        private ITokenStore _tokenStore;

        [TestInitialize]
        public void Setup()
        {
            DeviantArtOAuthClient oauthClient = new(Environment.GetEnvironmentVariable("DEVIANT_ART_CLIENT_ID")!,
                Environment.GetEnvironmentVariable("DEVIANT_ART_CLIENT_SECRET")!, new InMemoryTokenStore());
            _client = new AuthenticatedDeviantArtApiClient(oauthClient);
        }

        private static T LoadJsonFromFile<T>(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(json) ?? throw new InvalidOperationException(filePath);
        }

        [TestMethod]
        public async Task isTokenValidAsync_ShouldReturnPlaceboResponse()
        {
            
            var expectedResponse = LoadJsonFromFile<PlaceboResponse>("ExpectedResponses/Auth/PlaceboResponse.json");
            
            var result = await _client.IsTokenValidAsync();
            
            Assert.AreEqual(expectedResponse.Status, result.Status);
        }

        [TestMethod]
        public async Task GetDeviationAsync_ShouldReturnDeviation()
        {
            var expectedDeviation = LoadJsonFromFile<Deviation>("ExpectedResponses/Deviations/Deviation.json");
            
            var result = await _client.GetDeviationAsync(Ids.PoolByAllRich);
            
            Assert.AreEqual(expectedDeviation.DeviationId, result.DeviationId);
        }

        [TestMethod]
        public async Task BrowseHomeDeviationsAsync_ShouldReturnDeviantArtApiResponse()
        {
            
            const int limit = 10;
            const int offset = 0;
            const bool matureContent = false;
            
            var result = await _client.BrowseHomeDeviationsAsync(limit, offset, matureContent);
            
            Assert.IsFalse(result.Results.Count > 10);
        }

        [TestMethod]
        public async Task BrowseTagsAsync_ShouldReturnBrowseTagsResponse()
        {
            
            const string tag = "art";
            var expectedResponse = LoadJsonFromFile<BrowseTagsResponse>("ExpectedResponses/Browse/BrowseTags.json");
            
            var result = await _client.BrowseTagsAsync(tag);
            
            Assert.AreEqual(expectedResponse.Results.Count, result.Results.Count);
        }
    }
}