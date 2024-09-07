using System.Globalization;
using System.Text.Json;

namespace DeviantArt.Net.Modules.Util.Formatters;

internal class DateTimeNullableConverter : JsonConverter<DateTime?>
{
    private const string DateFormat = "yyyy-MM-ddTHH:mm:ssK";

    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var dateString = reader.GetString();
        if (string.IsNullOrEmpty(dateString))
        {
            return null;
        }

        return DateTime.ParseExact(dateString, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
        {
            writer.WriteStringValue(value.Value.ToString(DateFormat));
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}