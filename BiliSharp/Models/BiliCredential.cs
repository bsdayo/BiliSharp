using BiliSharp.Utils;

namespace BiliSharp.Models;

// ReSharper disable StringLiteralTypo
// ReSharper disable CommentTypo
// ReSharper disable IdentifierTypo
public class BiliCredential
{
    /// <summary>
    ///     Cookie 中的 bili_jct 值
    /// </summary>
    public string? BiliJct { get; set; } = null;

    /// <summary>
    ///     Cookie 中的 SESSDATA 值
    /// </summary>
    public string? SessData { get; set; } = null;

    /// <summary>
    ///     Cookie 中的 buvid3 值
    /// </summary>
    public string? Buvid3 { get; set; } = null;


    public BiliCredential RequireBiliJct()
    {
        if (BiliJct is null)
            BiliCredentialException.ThrowNoBiliJct();
        return this;
    }

    public BiliCredential RequireSessData()
    {
        if (SessData is null)
            BiliCredentialException.ThrowNoSessData();
        return this;
    }

    public BiliCredential RequireBuvid3()
    {
        if (Buvid3 is null)
            BiliCredentialException.ThrowNoBuvid3();
        return this;
    }

    public string BuildCookie()
    {
        var cb = new CookieBuilder();

        if (BiliJct is not null)
            cb.Add("bili_jct", BiliJct);
        if (SessData is not null)
            cb.Add("SESSDATA", SessData);
        if (Buvid3 is not null)
            cb.Add("buvid3", Buvid3);

        return cb.Build();
    }
}

public sealed class BiliCredentialException : BiliException
{
    private BiliCredentialException(string message)
        : base(message)
    {
    }

    public static void ThrowNoBiliJct()
    {
        throw new BiliCredentialException(
            $"操作需要 bili_jct 值，请实例化 {nameof(BiliCredential)} 类并在其中提供");
    }

    public static void ThrowNoSessData()
    {
        throw new BiliCredentialException(
            $"操作需要 SESSDATA 值，请实例化 {nameof(BiliCredential)} 类并在其中提供");
    }

    public static void ThrowNoBuvid3()
    {
        throw new BiliCredentialException(
            $"操作需要 buvid3 值，请实例化 {nameof(BiliCredential)} 类并在其中提供");
    }
}