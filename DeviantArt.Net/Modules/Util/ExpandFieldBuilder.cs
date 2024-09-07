using System.Linq.Expressions;

namespace DeviantArt.Net.Modules.Util;

internal static class ExpandFieldBuilder
{
    public static LambdaExpression[] Build(params LambdaExpression[] expressions)
    {
        return expressions.ToArray();
    }
}