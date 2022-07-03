using System.Text.Json.Serialization;

namespace BiliSharp.Models.Video;
#pragma warning disable CS8618

public class BiliVideoSubtitleInfo
{
    /// <summary>
    ///     是否允许提交字幕
    /// </summary>
    [JsonPropertyName("allow_submit")]
    public bool AllowSubmit { get; set; }

    /// <summary>
    ///     字幕列表
    /// </summary>
    [JsonPropertyName("list")]
    public BiliVideoSubtitle[] List { get; set; }
}

public class BiliVideoSubtitle
{
    /// <summary>
    ///     字幕 ID
    /// </summary>
    [JsonPropertyName("id")]
    public long Id { get; set; }

    /// <summary>
    ///     字幕语言
    /// </summary>
    [JsonPropertyName("lan")]
    public string Language { get; set; }

    /// <summary>
    ///     字幕语言名称
    /// </summary>
    [JsonPropertyName("lan_doc")]
    public string LanguageDoc { get; set; }

    /// <summary>
    ///     是否锁定
    /// </summary>
    [JsonPropertyName("is_lock")]
    public bool IsLock { get; set; }

    /// <summary>
    ///     字幕上传者 mid
    /// </summary>
    [JsonPropertyName("author_mid")]
    public long AuthorMid { get; set; }

    /// <summary>
    ///     JSON 格式字幕文件 url
    /// </summary>
    [JsonPropertyName("subtitle_url")]
    public string SubtitleUrl { get; set; }

    /// <summary>
    ///     字幕上传者信息
    /// </summary>
    [JsonPropertyName("author")]
    public BiliVideoSubtitleAuthor Author { get; set; }
}

public class BiliVideoSubtitleAuthor
{
    /// <summary>
    ///     字幕上传者 mid
    /// </summary>
    [JsonPropertyName("mid")]
    public long Mid { get; set; }

    /// <summary>
    ///     字幕上传者名称
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    ///     字幕上传者性别 （男/女/保密）
    /// </summary>
    [JsonPropertyName("sex")]
    public string Sex { get; set; }

    /// <summary>
    ///     字幕上传者头像 url
    /// </summary>
    [JsonPropertyName("face")]
    public string FaceUrl { get; set; }

    /// <summary>
    ///     字幕上传者签名
    /// </summary>
    [JsonPropertyName("sign")]
    public string Sign { get; set; }

    [JsonPropertyName("rank")] public int Rank { get; set; }

    [JsonPropertyName("birthday")] public int Birthday { get; set; }

    [JsonPropertyName("is_fake_account")] public int IsFakeAccount { get; set; }

    [JsonPropertyName("is_delete")] public int IsDeleted { get; set; }
}