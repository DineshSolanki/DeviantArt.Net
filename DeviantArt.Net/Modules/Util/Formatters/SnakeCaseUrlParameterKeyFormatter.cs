namespace DeviantArt.Net.Modules.Util.Formatters;


/// <summary>
/// Provides an implementation of <see cref="IUrlParameterKeyFormatter"/> that formats URL parameter keys in snake_case.
/// </summary>
public class SnakeCaseUrlParameterKeyFormatter : IUrlParameterKeyFormatter
{
    public string Format(string key)
    {
        if (string.IsNullOrEmpty(key))
        {
            return key;
        }

#if NETCOREAPP
        return string.Create(
            key.Length * 2, // Allocate enough space for potential underscores
            key,
            (chars, name) =>
            {
                var pos = 0;
                for (var i = 0; i < name.Length; i++)
                {
                    if (char.IsUpper(name[i]) && i > 0)
                    {
                        chars[pos++] = '_';
                    }
                    chars[pos++] = char.ToLowerInvariant(name[i]);
                }
            }
        );
#else
            var sb = new StringBuilder(key.Length * 2);
            for (int i = 0; i < key.Length; i++)
            {
                if (char.IsUpper(key[i]) && i > 0)
                {
                    sb.Append('_');
                }
                sb.Append(char.ToLowerInvariant(key[i]));
            }
            return sb.ToString();
#endif
    }
}