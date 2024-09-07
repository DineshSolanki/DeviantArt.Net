namespace DeviantArt.NetTest.Utils;

public static class Util
{
    private static readonly ITokenStore TokenStore = new JsonTokenStore();
    
    public static Client GetClientByGrantType(GrantType grantType)
    {
        return grantType switch
        {
            GrantType.AuthorizationCode => new Client(Environment.GetEnvironmentVariable("DEVIANT_ART_CLIENT_ID")!,
                Environment.GetEnvironmentVariable("DEVIANT_ART_CLIENT_SECRET")!, TokenStore, "http://localhost:8451/",
                Scope.Browse, Scope.Stash, Scope.Publish, Scope.Message, Scope.User, Scope.UserManage),
            GrantType.ClientCredentials => new Client(Environment.GetEnvironmentVariable("DEVIANT_ART_CLIENT_ID")!,
                Environment.GetEnvironmentVariable("DEVIANT_ART_CLIENT_SECRET")!, TokenStore),
            GrantType.Implicit => throw new NotImplementedException(),
            _ => throw new ArgumentOutOfRangeException(nameof(grantType), grantType, null)
        };
    }

    public static T LoadJsonFromFile<T>(string filePath)
    {
        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<T>(json) ?? throw new InvalidOperationException(filePath);
    }
}