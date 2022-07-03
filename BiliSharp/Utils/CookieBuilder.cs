namespace BiliSharp.Utils;

internal class CookieBuilder
{
    private List<string> CookieSegments { get; } = new();

    internal CookieBuilder Add(string key, string value)
    {
        CookieSegments.Add($"{key}={value}");
        return this;
    }

    internal string Build()
    {
        return string.Join("; ", CookieSegments);
    }
}