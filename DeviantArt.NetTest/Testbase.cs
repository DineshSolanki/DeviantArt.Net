namespace DeviantArt.NetTest;

[TestClass]
public class Testbase
{
    protected readonly Client Client = Util.GetClientByGrantType(GrantType.AuthorizationCode);
}