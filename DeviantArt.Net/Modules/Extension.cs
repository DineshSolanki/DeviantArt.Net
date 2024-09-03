using System.ComponentModel;
using System.Reflection;

namespace DeviantArt.Net.Modules;

public static class Extensions
{
    public static string GetDescription<T>(this T enumerationValue) where T : struct
    {
        var attribute =
            enumerationValue.GetType()
                    .GetTypeInfo()
                    .GetMember(enumerationValue.ToString()!)
                    .FirstOrDefault(member => member.MemberType == MemberTypes.Field)
                    ?.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .SingleOrDefault()
                as DescriptionAttribute;

        return (attribute?.Description ?? enumerationValue.ToString())!;
    }
}