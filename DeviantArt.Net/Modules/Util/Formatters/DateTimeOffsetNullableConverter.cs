using System.Globalization;
using System.Text.Json;

namespace DeviantArt.Net.Modules.Util.Formatters;

internal class DateTimeOffsetNullableConverter<T>  : JsonConverter<T>
{
    private const string DateFormat = "yyyy-MM-ddTHH:mm:sszzz";

    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var dateString = reader.GetString();
        return string.IsNullOrEmpty(dateString) ? default : (T)(object)DateTimeOffset.ParseExact(dateString, DateFormat, CultureInfo.InvariantCulture);
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        if (value is DateTimeOffset dateTime)
        {
            writer.WriteStringValue(dateTime.ToString(DateFormat));
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}

