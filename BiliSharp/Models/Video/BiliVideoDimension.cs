using System.Text.Json.Serialization;

namespace BiliSharp.Models.Video;

public class BiliVideoDimension
{
    /// <summary>
    ///     当前分P 宽度
    /// </summary>
    [JsonPropertyName("width")]
    public int Width { get; set; }

    /// <summary>
    ///     当前分P 高度
    /// </summary>
    [JsonPropertyName("height")]
    public int Height { get; set; }

    /// <summary>
    ///     是否将宽高对换
    /// </summary>
    [JsonPropertyName("rotate")]
    public BiliVideoDimensionRotate Rotate { get; set; }
}

public enum BiliVideoDimensionRotate
{
    /// <summary>
    ///     正常
    /// </summary>
    Normal = 0,

    /// <summary>
    ///     宽高对换
    /// </summary>
    Rotate = 1
}