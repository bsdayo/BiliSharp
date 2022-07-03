namespace BiliSharp.Apis;

public static class BiliVideoApi
{
    /// <summary>
    ///     视频信息
    /// </summary>
    public static readonly BiliApi Info = new()
    {
        Method = HttpMethod.Get,
        Url = "https://api.bilibili.com/x/web-interface/view"
    };

    /// <summary>
    ///     视频点赞
    /// </summary>
    public static readonly BiliApi SetLike = new()
    {
        Method = HttpMethod.Post,
        Url = "https://api.bilibili.com/x/web-interface/archive/like"
    };

    /// <summary>
    ///     是否已点赞
    /// </summary>
    public static readonly BiliApi HasLiked = new()
    {
        Method = HttpMethod.Get,
        Url = "https://api.bilibili.com/x/web-interface/archive/has/like"
    };

    public static readonly BiliApi SetCoin = new()
    {
        Method = HttpMethod.Post,
        Url = "https://api.bilibili.com/x/web-interface/coin/add"
    };

    public static readonly BiliApi GetCoin = new()
    {
        Method = HttpMethod.Get,
        Url = "https://api.bilibili.com/x/web-interface/archive/coins"
    };

    public static readonly BiliApi SetFavorite = new()
    {
        Method = HttpMethod.Post,
        Url = "https://api.bilibili.com/x/v3/fav/resource/deal"
    };

    public static readonly BiliApi HasFavored = new()
    {
        Method = HttpMethod.Get,
        Url = "https://api.bilibili.com/x/v2/fav/video/favoured"
    };

    public static readonly BiliApi SetTriple = new()
    {
        Method = HttpMethod.Post,
        Url = "https://api.bilibili.com/x/web-interface/archive/like/triple"
    };
}