using System.Text.Json.Serialization;

#pragma warning disable CS8618

namespace BiliSharp.Models.Video;

public class BiliVideoPage
{
    /// <summary>
    ///     当前分P cid
    /// </summary>
    [JsonPropertyName("cid")]
    public long Cid { get; set; }

    /// <summary>
    ///     当前分P索引
    /// </summary>
    [JsonPropertyName("page")]
    public int Page { get; set; }

    /// <summary>
    ///     视频来源 <br />
    ///     vupload：普通上传（B站）<br />
    ///     hunan：芒果TV <br />
    ///     qq：腾讯
    /// </summary>
    [JsonPropertyName("from")]
    public string From { get; set; }

    /// <summary>
    ///     当前分P标题
    /// </summary>
    [JsonPropertyName("part")]
    public string Title { get; set; }

    /// <summary>
    ///     当前分P持续时间 （单位：秒）
    /// </summary>
    [JsonPropertyName("duration")]
    public int Duration { get; set; }

    /// <summary>
    ///     站外视频 vid
    /// </summary>
    [JsonPropertyName("vid")]
    public string Vid { get; set; }

    /// <summary>
    ///     站外视频跳转 url
    /// </summary>
    [JsonPropertyName("weblink")]
    public string WebLink { get; set; }

    /// <summary>
    ///     当前分P分辨率
    /// </summary>
    [JsonPropertyName("dimension")]
    public BiliVideoDimension Dimension { get; set; }
}