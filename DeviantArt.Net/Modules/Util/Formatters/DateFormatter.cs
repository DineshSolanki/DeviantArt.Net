using System.Reflection;

namespace DeviantArt.Net.Modules.Util.Formatters;

internal class CustomDateUrlParameterFormatter : DefaultUrlParameterFormatter
{
    public override string? Format(object? value, ICustomAttributeProvider attributeProvider, Type type)
    {
        if (value is DateOnly dt)
        {
            return dt.ToString("yyyy-MM-dd");
        }

        return base.Format(value, attributeProvider, type);
    }
}