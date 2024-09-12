namespace DeviantArt.Net.Modules.Util.Formatters;

public class UnixTimestampConverter : JsonConverter<DateTimeOffset>
{
    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var unixTime = reader.GetInt64();
        return DateTimeOffset.FromUnixTimeSeconds(unixTime);
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
    {
        var unixTime = value.ToUnixTimeSeconds();
        writer.WriteNumberValue(unixTime);
    }
}