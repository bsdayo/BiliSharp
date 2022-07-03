using System.Text.Json.Serialization;

namespace BiliSharp.Models.Video;

public class BiliVideoRights
{
    /// <summary>
    ///     是否支持充电
    /// </summary>
    [JsonPropertyName("elec")]
    public byte AllowElec { get; set; }

    /// <summary>
    ///     是否允许下载
    /// </summary>
    [JsonPropertyName("download")]
    public byte AllowDownload { get; set; }

    /// <summary>
    ///     是否为电影
    /// </summary>
    [JsonPropertyName("movie")]
    public byte IsMovie { get; set; }

    /// <summary>
    ///     是否为 PGC 付费
    /// </summary>
    [JsonPropertyName("pay")]
    public byte IsPgcPay { get; set; }

    /// <summary>
    ///     是否有高码率
    /// </summary>
    [JsonPropertyName("hd5")]
    public byte HighBitRate { get; set; }

    /// <summary>
    ///     是否显示“禁止转载“标志
    /// </summary>
    [JsonPropertyName("no_reprint")]
    public byte NoReprint { get; set; }

    /// <summary>
    ///     是否自动播放
    /// </summary>
    [JsonPropertyName("autoplay")]
    public byte Autoplay { get; set; }

    /// <summary>
    ///     是否为 UGC 付费
    /// </summary>
    [JsonPropertyName("ugc_pay")]
    public byte IsUgcPay { get; set; }

    /// <summary>
    ///     是否为互动视频
    /// </summary>
    [JsonPropertyName("is_stein_gate")]
    public byte IsSteinGate { get; set; }

    /// <summary>
    ///     是否为联合投稿
    /// </summary>
    [JsonPropertyName("is_cooperation")]
    public byte IsCooperation { get; set; }

    [JsonPropertyName("bp")] public byte Bp { get; set; }

    [JsonPropertyName("ugc_pay_preview")] public byte UgcPayPreview { get; set; }

    [JsonPropertyName("no_background")] public byte NoBackground { get; set; }
}