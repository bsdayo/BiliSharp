using System.Text.Json.Serialization;

namespace BiliSharp.Models.Video;

public class BiliVideoSetFavoriteResult
{
    [JsonPropertyName("prompt")] public bool Prompt { get; set; }
}

public class BiliVideoHasFavoredResult
{
    [JsonPropertyName("count")] public int Count { get; set; }

    [JsonPropertyName("favoured")] public bool Favored { get; set; }
}