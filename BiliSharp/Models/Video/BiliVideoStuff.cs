using System.Text.Json.Serialization;

namespace BiliSharp.Models.Video;
#pragma warning disable CS8618

public class BiliVideoStaff
{
    /// <summary>
    ///     成员 mid
    /// </summary>
    [JsonPropertyName("mid")]
    public long Mid { get; set; }

    /// <summary>
    ///     成员名称
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }

    /// <summary>
    ///     成员昵称
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    ///     成员头像 url
    /// </summary>
    [JsonPropertyName("face")]
    public string FaceUrl { get; set; }

    /// <summary>
    ///     成员大会员状态
    /// </summary>
    [JsonPropertyName("vip")]
    public BiliVideoStuffVip Vip { get; set; }

    /// <summary>
    ///     成员认证信息
    /// </summary>
    [JsonPropertyName("official")]
    public BiliVideoStuffOfficial Official { get; set; }

    /// <summary>
    ///     成员粉丝数
    /// </summary>
    [JsonPropertyName("follower")]
    public int Follower { get; set; }
}

public class BiliVideoStuffVip
{
    /// <summary>
    ///     成员会员类型
    /// </summary>
    [JsonPropertyName("type")]
    public BiliVipType Type { get; set; }

    /// <summary>
    ///     成员会员状态
    /// </summary>
    [JsonPropertyName("status")]
    public BiliVipStatus Status { get; set; }

    [JsonPropertyName("theme_type")] public int ThemeType { get; set; }
}

public class BiliVideoStuffOfficial
{
    /// <summary>
    ///     成员认证级别 <br />
    ///     0：无 <br />
    ///     1 2 7：个人认证 <br />
    ///     3 4 5 6：机构认证
    /// </summary>
    [JsonPropertyName("role")]
    public byte Role { get; set; }

    /// <summary>
    ///     成员认证名（无为 null）
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    ///     成员认证备注（无为 null）
    /// </summary>
    [JsonPropertyName("desc")]
    public string? Description { get; set; }

    /// <summary>
    ///     成员认证类型
    /// </summary>
    [JsonPropertyName("type")]
    public BiliVideoStuffOfficialType Type { get; set; }
}

public enum BiliVideoStuffOfficialType
{
    None = -1,
    Official = 0
}