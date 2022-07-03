using System.Text.Json.Serialization;
using BiliSharp.Models.Video;

#pragma warning disable CS8618

namespace BiliSharp.Models;

public class BiliVideoInfo
{
    /// <summary>
    ///     视频 AV 号
    /// </summary>
    [JsonPropertyName("aid")]
    public long AvId { get; set; }

    /// <summary>
    ///     视频 BV 号
    /// </summary>
    [JsonPropertyName("bvid")]
    public string BvId { get; set; }

    /// <summary>
    ///     视频标题
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }

    /// <summary>
    ///     稿件分P总数
    /// </summary>
    [JsonPropertyName("videos")]
    public int Videos { get; set; } = 1;

    /// <summary>
    ///     分区 tid
    /// </summary>
    [JsonPropertyName("tid")]
    public int Tid { get; set; }

    /// <summary>
    ///     分区名称
    /// </summary>
    [JsonPropertyName("tname")]
    public string Tname { get; set; }

    /// <summary>
    ///     视频 1P cid
    /// </summary>
    [JsonPropertyName("cid")]
    public long Cid { get; set; }

    /// <summary>
    ///     视频类型
    /// </summary>
    [JsonPropertyName("copyright")]
    public BiliVideoCopyright Copyright { get; set; }

    /// <summary>
    ///     稿件封面图片url
    /// </summary>
    [JsonPropertyName("pic")]
    public string PictureUrl { get; set; }

    /// <summary>
    ///     视频状态
    /// </summary>
    [JsonPropertyName("state")]
    public BiliVideoState State { get; set; }

    /// <summary>
    ///     投稿时间（时间戳）
    /// </summary>
    [JsonPropertyName("ctime")]
    public long CreateTime { get; set; }

    /// <summary>
    ///     发布时间（时间戳）
    /// </summary>
    [JsonPropertyName("pubdate")]
    public long PublishTime { get; set; }

    /// <summary>
    ///     视频简介
    /// </summary>
    [JsonPropertyName("desc")]
    public string Description { get; set; }

    /// <summary>
    ///     新版视频简介
    /// </summary>
    [JsonPropertyName("desc_v2")]
    public BiliVideoDescriptionV2[] DescriptionV2 { get; set; }

    /// <summary>
    ///     视频 1P 分辨率
    /// </summary>
    [JsonPropertyName("dimension")]
    public BiliVideoDimension Dimension { get; set; }

    /// <summary>
    ///     视频总时长（所有分P）
    /// </summary>
    [JsonPropertyName("duration")]
    public int Duration { get; set; }

    /// <summary>
    ///     撞车视频跳转 avid（仅撞车视频存在此字段）
    /// </summary>
    [JsonPropertyName("forward")]
    public long? Forward { get; set; }

    /// <summary>
    ///     稿件参与的活动 ID
    /// </summary>
    [JsonPropertyName("mission_id")]
    public int? MissionId { get; set; }

    /// <summary>
    ///     重定向url <br />
    ///     仅番剧或影视视频存在此字段，用于番剧、影视的 av/bv -> ep
    /// </summary>
    [JsonPropertyName("redirect_url")]
    public string? RedirectUrl { get; set; }

    /// <summary>
    ///     视频同步发布的动态的文字内容
    /// </summary>
    [JsonPropertyName("dynamic")]
    public string Dynamic { get; set; }

    /// <summary>
    ///     视频 UP 主信息
    /// </summary>
    [JsonPropertyName("owner")]
    public BiliVideoOwner Owner { get; set; }

    /// <summary>
    ///     视频分 P 列表
    /// </summary>
    [JsonPropertyName("pages")]
    public BiliVideoPage[] Pages { get; set; }

    /// <summary>
    ///     视频属性标志
    /// </summary>
    [JsonPropertyName("rights")]
    public BiliVideoRights Rights { get; set; }

    /// <summary>
    ///     视频状态数
    /// </summary>
    [JsonPropertyName("stat")]
    public BiliVideoStat Stat { get; set; }

    /// <summary>
    ///     视频 CC 字幕信息
    /// </summary>
    [JsonPropertyName("subtitle")]
    public BiliVideoSubtitleInfo Subtitle { get; set; }

    /// <summary>
    ///     青少年模式
    /// </summary>
    [JsonPropertyName("teenage_mode")]
    public byte TeenageMode { get; set; }

    /// <summary>
    ///     用户装扮信息
    /// </summary>
    [JsonPropertyName("user_garb")]
    public BiliVideoUserGarb UserGarb { get; set; }

    /// <summary>
    ///     合作成员列表（非合作视频无此项）
    /// </summary>
    [JsonPropertyName("staff")]
    public BiliVideoStaff[]? Staff { get; set; }

    /// <summary>
    ///     视频获得荣誉
    /// </summary>
    [JsonPropertyName("honor_reply")]
    public BiliVideoHonorReply HonorReply { get; set; }

    [JsonPropertyName("no_cache")] public bool NoCache { get; set; }

    [JsonPropertyName("premiere")] public object? Premiere { get; set; }

    [JsonPropertyName("is_chargeable_season")]
    public bool IsChargeableSeason { get; set; }

    [JsonPropertyName("is_season_display")]
    public bool IsSeasonDisplay { get; set; }
}

public class BiliVideoUserGarb
{
    [JsonPropertyName("url_image_ani_cut")]
    public string UrlImageAniCut { get; set; }
}