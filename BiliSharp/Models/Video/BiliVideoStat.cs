using System.Text.Json.Serialization;

#pragma warning disable CS8618

namespace BiliSharp.Models.Video;

public class BiliVideoStat
{
    /// <summary>
    ///     视频 AV 号
    /// </summary>
    [JsonPropertyName("aid")]
    public int AvId { get; set; }

    /// <summary>
    ///     播放数
    /// </summary>
    [JsonPropertyName("view")]
    public int View { get; set; }

    /// <summary>
    ///     弹幕数
    /// </summary>
    [JsonPropertyName("danmaku")]
    public int Danmaku { get; set; }

    /// <summary>
    ///     评论数
    /// </summary>
    [JsonPropertyName("reply")]
    public int Reply { get; set; }

    /// <summary>
    ///     收藏数
    /// </summary>
    [JsonPropertyName("favorite")]
    public int Favorite { get; set; }

    /// <summary>
    ///     投币数
    /// </summary>
    [JsonPropertyName("coin")]
    public int Coin { get; set; }

    /// <summary>
    ///     分享数
    /// </summary>
    [JsonPropertyName("share")]
    public int Share { get; set; }

    /// <summary>
    ///     当前排名
    /// </summary>
    [JsonPropertyName("now_rank")]
    public int NowRank { get; set; }

    /// <summary>
    ///     历史最高排名
    /// </summary>
    [JsonPropertyName("his_rank")]
    public int HistoryRank { get; set; }

    /// <summary>
    ///     获赞数
    /// </summary>
    [JsonPropertyName("like")]
    public int Like { get; set; }

    /// <summary>
    ///     点踩数（恒为 0）
    /// </summary>
    [JsonPropertyName("dislike")]
    public int Dislike { get; set; } = 0;

    /// <summary>
    ///     视频评分
    /// </summary>
    [JsonPropertyName("evaluation")]
    public string Evaluation { get; set; }

    /// <summary>
    ///     警告/争议提示信息
    /// </summary>
    [JsonPropertyName("argue_msg")]
    public string ArgueMessage { get; set; }
}