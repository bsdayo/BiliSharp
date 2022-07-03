using System.Text.Json.Serialization;

namespace BiliSharp.Models.Video;

public class BiliVideoSetCoinResult
{
    /// <summary>
    ///     是否同时点赞成功
    /// </summary>
    [JsonPropertyName("like")]
    public bool Like { get; set; }
}

public class BiliVideoGetCoinResult
{
    /// <summary>
    ///     投币数量
    /// </summary>
    [JsonPropertyName("multiply")]
    public byte Count { get; set; }
}