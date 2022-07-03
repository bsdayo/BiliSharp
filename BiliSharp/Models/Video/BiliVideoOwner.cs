using System.Text.Json.Serialization;

#pragma warning disable CS8618

namespace BiliSharp.Models.Video;

public class BiliVideoOwner
{
    /// <summary>
    ///     UP 主 mid
    /// </summary>
    [JsonPropertyName("mid")]
    public long Mid { get; set; }

    /// <summary>
    ///     UP 主名称
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    ///     UP 主头像
    /// </summary>
    [JsonPropertyName("face")]
    public string FaceUrl { get; set; }
}