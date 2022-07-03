using System.Text.Json.Serialization;

#pragma warning disable CS8618

namespace BiliSharp.Models.Video;

public class BiliVideoHonorReply
{
    [JsonPropertyName("honor")] public BiliVideoHonor[]? Honor { get; set; }
}

public class BiliVideoHonor
{
    [JsonPropertyName("aid")] public long AvId { get; set; }

    [JsonPropertyName("desc")] public string Description { get; set; }

    [JsonPropertyName("type")] public int Type { get; set; }

    [JsonPropertyName("weekly_recommend_num")]
    public int WeeklyRecommendNum { get; set; }
}