using System.Reflection;

namespace DeviantArt.Net.Modules;

internal static class Extensions
{
    internal static string GetDescription<T>(this T enumerationValue) where T : struct
    {
        var type = enumerationValue.GetType();
        var memberInfo = type.GetTypeInfo().GetMember(enumerationValue.ToString()!).FirstOrDefault(member => member.MemberType == MemberTypes.Field);

        if (memberInfo?.GetCustomAttributes(typeof(DescriptionAttribute), false).SingleOrDefault() is DescriptionAttribute descriptionAttribute)
        {
            return descriptionAttribute.Description;
        }

        return memberInfo?.GetCustomAttributes(typeof(EnumMemberAttribute), false)
            .SingleOrDefault() is EnumMemberAttribute enumMemberAttribute 
            ? enumMemberAttribute.Value : enumerationValue.ToString()!;
    }

    internal static void AddIfNotNull<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue? value)
        where TValue : class
    {
        if (value != null)
        {
            dictionary[key] = value;
        }
    }
    
    internal static void AddEnumArray<TEnum>(this Dictionary<string, object> dictionary, string keyPrefix, IEnumerable<TEnum>? enumArray) where TEnum : struct, Enum
    {
        enumArray?.Select((enumValue, index) => new { enumValue, index })
            .ToList()
            .ForEach(e => dictionary.Add($"{keyPrefix}[{e.index}]", e.enumValue.GetDescription()));
    }
    
    internal static void AddEnumerable<T>(this Dictionary<string, object> dictionary, string keyPrefix, IEnumerable<T>? enumerable)
    {
        enumerable?.Select((value, index) => new { value, index })
            .ToList()
            .ForEach(e => dictionary[$"{keyPrefix}[{e.index}]"] = e.value.ToString());
    }
}