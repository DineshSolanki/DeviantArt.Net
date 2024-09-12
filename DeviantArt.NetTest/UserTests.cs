namespace DeviantArt.NetTest;

[TestClass]
public class UserTests : Testbase
{
    
    [TestMethod]
    public async Task GetDAMNAuthToken()
    {
        var response = await Client.GetDamnAuthToken();
        Assert.IsNotNull(response.DamnToken);
    }
    
    [TestMethod]
    public async Task GetFriendsOfUser()
    {
        var response = await Client.GetFriendsOfUser();
        Assert.IsNotNull(response.Results);
    }
    
    [TestMethod]
    public async Task SearchFriendsOfUser()
    {
        var response = await Client.SearchFriendsOfUser(Ids.ArtistUsername);
        Assert.IsTrue(response.Results.Count > 0);
    }
    
    [TestMethod]
    public async Task WatchUser()
    {
        var response = await Client.WatchUser("hacke", new WatchRequest());
        Assert.IsTrue(response.Success);
    }
    
    [TestMethod]
    public async Task UnwatchUser()
    {
        var response = await Client.UnwatchUser("hacke");
        Assert.IsTrue(response.Success);
    }

    [TestMethod]
    public async Task CheckIfUserIsWatchingYou()
    {
        var response = await Client.IsUserWatchingMe("hacke");
        Assert.IsFalse(response);
    }
    
    [TestMethod]
    public async Task GetUserProfile()
    {
        var response = await Client.GetUserProfile();
        Assert.IsNotNull(response.User);
    }
    
    [TestMethod]
    public async Task GetUserPosts()
    {
        var response = await Client.GetUserPosts(Ids.ArtistUsername);
        Assert.IsNotNull(response.Results.Count > 0);
    }
    
    [TestMethod]
    public async Task UpdateUserProfile()
    {
        var countriesResponse = await Client.GetDataCountriesAsync();
        var USA = countriesResponse.Results.First();
        var update = new ProfileUpdateRequest
        {
            UserIsArtist = true,
            ArtistLevel = ArtistLevel.Professional,
            ArtistSpecialty = ArtistSpecialty.DigitalArt,
            Country =  USA,
            Website = "https://www.deviantart.com",
            WebsiteLabel = "DeviantArt",
            TagLine = "Art is my life",
            ShowBadges = true,
            Interests =
            [
                new Interest { Type = InterestType.FavoriteVisualArtist, Value = "Leonardo da Vinci" },
                new Interest { Type = InterestType.FavoriteMovies, Value = "The Matrix" },
                new Interest { Type = InterestType.FavoriteTvShows, Value = "Black Mirror" }
            ],
            SocialLinks =
            [
                new SocialLink { Type = SocialLinkType.Facebook, Url = "https://facebook.com/myprofile" },
                new SocialLink { Type = SocialLinkType.Instagram, Url = "https://instagram.com/myprofile" },
                new SocialLink { Type = SocialLinkType.Twitter, Url = "https://twitter.com/myprofile" }
            ]
        };
        var response = await Client.UpdateUserProfileAsync(update);
        Assert.IsTrue(response.Success);
    }
    
    [TestMethod]
    public async Task PostStatus()
    {
        var response = await Client.PostStatusAsync(new PostStatusRequest {Body = "Test"});
        Console.WriteLine(response.StatusId);
        Assert.IsNotNull(response.StatusId);
    }
    
    [TestMethod]
    public async Task GetUserTiers()
    {
        var response = await Client.GetUserTiers(Ids.ArtistUsername);
        Assert.IsTrue(response.Results.Count == 0);
    }
    
    [TestMethod]
    public async Task GetUserWatchers()
    {
        var response = await Client.GetUserWatchers(Ids.ArtistUsername);
        Assert.IsTrue(response.Results.Count > 0);
    }
    
    [TestMethod]
    public async Task WhoAmI()
    {
        var response = await Client.WhoAmI();
        Assert.IsNotNull(response.Username);
    }
    
    [TestMethod]
    public async Task WhoIs()
    {
        var response = await Client.WhoIs(Ids.ArtistUsername);
        Assert.IsTrue(response.Results.First().UserId == Ids.ArtistUserId);
    }
}