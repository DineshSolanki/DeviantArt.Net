using System.Text.Json;

namespace DeviantArt.Net.Modules.Util.converter;

public class EnumArrayConverter<T> : JsonConverter<T[]> where T : Enum
{
    public override T[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var enumValues = new List<T>();

        while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
        {
            var stringValue = reader.GetString();
            var enumValue = EnumExtensions.GetEnumFromString<T>(stringValue);
            enumValues.Add(enumValue);
        }

        return enumValues.ToArray();
    }

    public override void Write(Utf8JsonWriter writer, T[] value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        foreach (var enumValue in value)
        {
            var stringValue = EnumExtensions.GetEnumValue(enumValue);
            writer.WriteStringValue(stringValue);
        }
        writer.WriteEndArray();
    }
}

public static class EnumExtensions
{
    public static string GetEnumValue<T>(T enumValue) where T : Enum
    {
        var type = enumValue.GetType();
        var memInfo = type.GetMember(enumValue.ToString());
        var attributes = memInfo[0].GetCustomAttributes(typeof(EnumMemberAttribute), false);
        return ((EnumMemberAttribute)attributes[0]).Value;
    }

    public static T GetEnumFromString<T>(string value) where T : Enum
    {
        var type = typeof(T);
        foreach (var field in type.GetFields())
        {
            var attribute = Attribute.GetCustomAttribute(field, typeof(EnumMemberAttribute)) as EnumMemberAttribute;
            if (attribute != null && attribute.Value == value)
            {
                return (T)field.GetValue(null);
            }
        }
        throw new ArgumentException($"Unknown value: {value}");
    }
}