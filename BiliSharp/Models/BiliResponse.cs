using System.Text.Json.Serialization;

#pragma warning disable CS8618

namespace BiliSharp.Models;

public class BiliResponse
{
    [JsonPropertyName("code")] public int Code { get; set; }

    [JsonPropertyName("message")] public string Message { get; set; }

    [JsonPropertyName("ttl")] public int Ttl { get; set; }
}

public class BiliResponse<TData>
{
    [JsonPropertyName("code")] public int Code { get; set; }

    [JsonPropertyName("message")] public string Message { get; set; }

    [JsonPropertyName("ttl")] public int Ttl { get; set; }

    [JsonPropertyName("data")] public TData Data { get; set; }
}