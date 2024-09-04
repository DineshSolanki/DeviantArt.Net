using System.Linq.Expressions;
using System.Reflection;

namespace DeviantArt.Net.Modules.Util;
public static class FieldSelector
{
    public static string GetFieldForKey<TSource>(Expression<Func<TSource, object?>> keySelector)
    {
        var memberExpression = keySelector.Body as MemberExpression;

        if (memberExpression == null && keySelector.Body is UnaryExpression unaryExpression)
        {
            memberExpression = unaryExpression.Operand as MemberExpression;
        }

        if (memberExpression == null)
        {
            throw new ArgumentException("Invalid expression format", nameof(keySelector));
        }

        // Build the full property path
        var propertyPath = new List<string>();
        while (memberExpression != null)
        {
            var propertyInfo = memberExpression.Member as PropertyInfo;
            if (propertyInfo == null) break;

            // Get JsonPropertyName if exists, otherwise use the property name
            var jsonPropertyNameAttribute = propertyInfo.GetCustomAttribute<JsonPropertyNameAttribute>();
            propertyPath.Insert(0, jsonPropertyNameAttribute?.Name ?? propertyInfo.Name);

            memberExpression = memberExpression.Expression as MemberExpression;
        }

        return string.Join(".", propertyPath);
    }

    public static string GetFieldsForKeys(params LambdaExpression[] keySelectors)
    {
        var fields = (from keySelector in keySelectors
                let method = typeof(FieldSelector).GetMethod(nameof(GetFieldForKey), BindingFlags.Public | BindingFlags.Static)
                    ?.MakeGenericMethod(keySelector.Parameters[0].Type)
                let convertedExpression = Expression.Lambda(typeof(Func<,>).MakeGenericType(keySelector.Parameters[0].Type, typeof(object)), Expression.Convert(keySelector.Body, typeof(object)), keySelector.Parameters)
                select method?.Invoke(null, [convertedExpression])).OfType<object>()
            .Cast<string>()
            .ToList();

        return string.Join(",", fields);
    }
}