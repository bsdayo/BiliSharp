using System.Text.Json.Serialization;

#pragma warning disable CS8618

namespace BiliSharp.Models.Video;

public class BiliVideoDescriptionV2
{
    /// <summary>
    ///     简介内容
    /// </summary>
    [JsonPropertyName("raw_text")]
    public string RawText { get; set; }

    [JsonPropertyName("type")] public int Type { get; set; }

    [JsonPropertyName("biz_id")] public int BizId { get; set; }
}