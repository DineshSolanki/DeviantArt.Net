using System.Globalization;

namespace DeviantArt.NetTest.Utils;

public static class Ids
{
    public static readonly Guid PoolByAllRich = new("4F494EC9-B8E9-CE6B-AC56-5D4ADBEDD8E2");
    public const string FolderId = "e5ed1544-6702-3085-877b-b63c6aa61c66";
    public const string TagName = "art";
    public const string ArtistUsername = "abysswolf";
    public const string ArtistUserId = "44476E18-17EE-CAF6-74AD-402BE2B0B4C3";
    public const string JacksMafiaUsername = "jacksmafia";
    public static readonly Guid JacksMafiaWweArtDeviationId = new("022DC6C3-F3B6-EF71-51BA-3540F8FD4BBF");
    public const string JacksMafiaWweArtCommentIdOfKingOfDeath = "16CBC8A1-D957-5B0C-B952-8C9127618091";
    public static readonly DateTimeOffset JacksMafiaWweArtCommentDateOfKingOfDeath = DateTimeOffset.ParseExact("2016-03-21T12:11:52-0700", "yyyy-MM-ddTHH:mm:sszzz", CultureInfo.InvariantCulture);
    public static readonly Guid JournalDeviationId = Guid.Parse("564DEA2F-FA18-0701-E9D1-1D999FC230B8");
}