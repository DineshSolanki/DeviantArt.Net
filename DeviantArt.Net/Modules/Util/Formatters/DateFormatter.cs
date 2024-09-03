using System.Reflection;

namespace DeviantArt.Net.Modules.Util.Formatters;

public class CustomDateUrlParameterFormatter : IUrlParameterFormatter
{
    public string? Format(object? value, ICustomAttributeProvider attributeProvider, Type type)
    {
        if (value is DateOnly dt)
        {
            return dt.ToString("yyyy-MM-dd");
        }

        return value?.ToString();
    }
}