namespace BiliSharp.Utils;

internal class QueryBuilder
{
    private readonly Dictionary<string, string> _params = new();

    internal QueryBuilder Add(string key, string value)
    {
        _params[key] = value;
        return this;
    }

    internal string Build()
    {
        var queryString = _params.Aggregate("", (current, param) =>
            current + $"&{param.Key}={param.Value}");
        return "?" + queryString[1..];
    }
}