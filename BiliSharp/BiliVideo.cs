using BiliSharp.Apis;
using BiliSharp.Models;
using BiliSharp.Models.Video;
using BiliSharp.Utils;

namespace BiliSharp;

public class BiliVideo : BiliClient
{
    /// <summary>
    ///     视频 AV 号
    /// </summary>
    public long AvId { get; }

    /// <summary>
    ///     视频 BV 号
    /// </summary>
    public string BvId { get; }

    /// <summary>
    ///     使用 AV 号构造视频对象，BV 号将自动计算
    /// </summary>
    /// <param name="avid">视频 AV 号</param>
    /// <param name="credential">认证信息</param>
    /// <param name="client">自定义 HTTP Client</param>
    public BiliVideo(long avid, BiliCredential? credential = null, HttpClient? client = null)
        : base(credential, client)
    {
        AvId = avid;
        BvId = BiliUtils.Av2Bv(avid);
    }

    /// <summary>
    ///     使用 BV 号构造视频对象，AV 号将自动计算
    /// </summary>
    /// <param name="bvid">视频 BV 号</param>
    /// <param name="credential">认证信息</param>
    /// <param name="client">自定义 HTTP Client</param>
    public BiliVideo(string bvid, BiliCredential? credential = null, HttpClient? client = null)
        : base(credential, client)
    {
        AvId = BiliUtils.Bv2Av(bvid);
        BvId = bvid;
    }


    /// <summary>
    ///     同步获取视频信息
    /// </summary>
    /// <param name="useAvId">使用 AV 号构造请求</param>
    /// <returns>视频信息</returns>
    /// <exception cref="BiliNetworkException">网络错误</exception>
    /// <exception cref="BiliOperationException">操作失败</exception>
    public BiliVideoInfo GetInfo(bool useAvId = false)
    {
        return NetClient.BiliRequest<BiliVideoInfo>(BiliVideoApi.Info, Credential,
            useAvId
                ? new QueryBuilder().Add("aid", AvId.ToString())
                : new QueryBuilder().Add("bvid", BvId));
    }

    /// <summary>
    ///     异步获取视频信息
    /// </summary>
    /// <param name="useAvId">使用 AV 号构造请求</param>
    /// <returns>视频信息</returns>
    /// <exception cref="BiliNetworkException">网络错误</exception>
    /// <exception cref="BiliOperationException">操作失败</exception>
    public async Task<BiliVideoInfo> GetInfoAsync(bool useAvId = false)
    {
        return await NetClient.BiliRequestAsync<BiliVideoInfo>(BiliVideoApi.Info, Credential,
            useAvId
                ? new QueryBuilder().Add("aid", AvId.ToString())
                : new QueryBuilder().Add("bvid", BvId));
    }


    /// <summary>
    ///     同步点赞视频（需要 SESSDATA 和 bili_jct 值）
    /// </summary>
    /// <param name="like">是否点赞</param>
    /// <param name="useAvId">使用 AV 号构造请求</param>
    /// <exception cref="BiliNetworkException">网络错误</exception>
    /// <exception cref="BiliOperationException">操作失败</exception>
    public void SetLike(bool like, bool useAvId = false)
    {
        var data = new Dictionary<string, string>();

        if (useAvId)
            data.Add("aid", AvId.ToString());
        else
            data.Add("bvid", BvId);

        data.Add("like", like ? "1" : "2");

        NetClient.BiliRequest(BiliVideoApi.SetLike, Credential.RequireSessData(),
            data: data);
    }

    /// <summary>
    ///     异步点赞视频（需要 SESSDATA 和 bili_jct 值）
    /// </summary>
    /// <param name="like">是否点赞</param>
    /// <param name="useAvId">使用 AV 号构造请求</param>
    /// <exception cref="BiliNetworkException">网络错误</exception>
    /// <exception cref="BiliOperationException">操作失败</exception>
    public async Task SetLikeAsync(bool like, bool useAvId = false)
    {
        var data = new Dictionary<string, string>();

        if (useAvId)
            data.Add("aid", AvId.ToString());
        else
            data.Add("bvid", BvId);

        data.Add("like", like ? "1" : "2");

        await NetClient.BiliRequestAsync(BiliVideoApi.SetLike, Credential.RequireSessData(),
            data: data);
    }


    /// <summary>
    ///     同步获取视频是否被点赞（需要 SESSDATA 值）
    /// </summary>
    /// <param name="useAvId">使用 AV 号构造请求</param>
    /// <returns>是否已点赞</returns>
    /// <exception cref="BiliNetworkException">网络错误</exception>
    /// <exception cref="BiliOperationException">操作失败</exception>
    public bool HasLiked(bool useAvId = false)
    {
        var result = NetClient.BiliRequest<byte>(BiliVideoApi.HasLiked, Credential.RequireSessData(),
            useAvId
                ? new QueryBuilder().Add("aid", AvId.ToString())
                : new QueryBuilder().Add("bvid", BvId));
        return result == 1;
    }

    /// <summary>
    ///     异步获取视频是否被点赞（需要 SESSDATA 值）
    /// </summary>
    /// <param name="useAvId">使用 AV 号构造请求</param>
    /// <returns>是否已点赞</returns>
    /// <exception cref="BiliNetworkException">网络错误</exception>
    /// <exception cref="BiliOperationException">操作失败</exception>
    public async Task<bool> HasLikedAsync(bool useAvId = false)
    {
        var result = await NetClient.BiliRequestAsync<byte>(BiliVideoApi.HasLiked, Credential.RequireSessData(),
            useAvId
                ? new QueryBuilder().Add("aid", AvId.ToString())
                : new QueryBuilder().Add("bvid", BvId));
        return result == 1;
    }


    /// <summary>
    ///     同步投币视频（需要 SESSDATA 和 bili_jct 值）
    /// </summary>
    /// <param name="count">投币数量</param>
    /// <param name="setLike">同时点赞</param>
    /// <param name="useAvId">使用 AV 号构造请求</param>
    /// <exception cref="BiliNetworkException">网络错误</exception>
    /// <exception cref="BiliOperationException">操作失败</exception>
    /// <returns>投币结果</returns>
    public BiliVideoSetCoinResult SetCoin(byte count, bool setLike = false, bool useAvId = false)
    {
        var data = new Dictionary<string, string>();

        if (useAvId)
            data.Add("aid", AvId.ToString());
        else
            data.Add("bvid", BvId);

        data.Add("multiply", count.ToString());
        data.Add("select_like", setLike ? "1" : "0");

        return NetClient.BiliRequest<BiliVideoSetCoinResult>(BiliVideoApi.SetCoin, Credential.RequireSessData(),
            data: data);
    }

    /// <summary>
    ///     异步投币视频（需要 SESSDATA 和 bili_jct 值）
    /// </summary>
    /// <param name="count">投币数量</param>
    /// <param name="setLike">同时点赞</param>
    /// <param name="useAvId">使用 AV 号构造请求</param>
    /// <exception cref="BiliNetworkException">网络错误</exception>
    /// <exception cref="BiliOperationException">操作失败</exception>
    /// <returns>投币结果</returns>
    public async Task<BiliVideoSetCoinResult> SetCoinAsync(byte count, bool setLike = false, bool useAvId = false)
    {
        var data = new Dictionary<string, string>();

        if (useAvId)
            data.Add("aid", AvId.ToString());
        else
            data.Add("bvid", BvId);

        data.Add("multiply", count.ToString());
        data.Add("select_like", setLike ? "1" : "0");

        return await NetClient.BiliRequestAsync<BiliVideoSetCoinResult>(BiliVideoApi.SetCoin,
            Credential.RequireSessData(),
            data: data);
    }


    /// <summary>
    ///     同步获取该账号投币数量（需要 SESSDATA 值）
    /// </summary>
    /// <param name="useAvId">使用 AV 号构造请求</param>
    /// <returns>投币数量</returns>
    /// <exception cref="BiliNetworkException">网络错误</exception>
    /// <exception cref="BiliOperationException">操作失败</exception>
    public byte GetCoin(bool useAvId = false)
    {
        var result = NetClient.BiliRequest<BiliVideoGetCoinResult>(BiliVideoApi.GetCoin, Credential.RequireSessData(),
            useAvId
                ? new QueryBuilder().Add("aid", AvId.ToString())
                : new QueryBuilder().Add("bvid", BvId));
        return result.Count;
    }

    /// <summary>
    ///     异步获取该账号投币数量（需要 SESSDATA 值）
    /// </summary>
    /// <param name="useAvId">使用 AV 号构造请求</param>
    /// <returns>投币数量</returns>
    /// <exception cref="BiliNetworkException">网络错误</exception>
    /// <exception cref="BiliOperationException">操作失败</exception>
    public async Task<byte> GetCoinAsync(bool useAvId = false)
    {
        var result = await NetClient.BiliRequestAsync<BiliVideoGetCoinResult>(BiliVideoApi.GetCoin,
            Credential.RequireSessData(),
            useAvId
                ? new QueryBuilder().Add("aid", AvId.ToString())
                : new QueryBuilder().Add("bvid", BvId));
        return result.Count;
    }

    /// <summary>
    ///     同步收藏视频（需要 SESSDATA 和 bili_jct 值）
    /// </summary>
    /// <param name="addMediaIds">需要加入的收藏夹 mlid</param>
    /// <exception cref="BiliNetworkException">网络错误</exception>
    /// <exception cref="BiliOperationException">操作失败</exception>
    /// <returns>收藏结果</returns>
    public BiliVideoSetFavoriteResult AddFavorite(IEnumerable<long> addMediaIds)
    {
        var data = new Dictionary<string, string>
        {
            { "rid", AvId.ToString() },
            { "type", "2" },
            { "add_media_ids", string.Join(",", addMediaIds) }
        };

        return NetClient.BiliRequest<BiliVideoSetFavoriteResult>(BiliVideoApi.SetFavorite,
            Credential.RequireSessData(), data: data);
    }

    /// <summary>
    ///     同步收藏视频（需要 SESSDATA 和 bili_jct 值）
    /// </summary>
    /// <param name="addMediaIds">需要加入的收藏夹 mlid</param>
    /// <exception cref="BiliNetworkException">网络错误</exception>
    /// <exception cref="BiliOperationException">操作失败</exception>
    /// <returns>收藏结果</returns>
    public async Task<BiliVideoSetFavoriteResult> AddFavoriteAsync(IEnumerable<long> addMediaIds)
    {
        var data = new Dictionary<string, string>
        {
            { "rid", AvId.ToString() },
            { "type", "2" },
            { "add_media_ids", string.Join(",", addMediaIds) }
        };

        return await NetClient.BiliRequestAsync<BiliVideoSetFavoriteResult>(BiliVideoApi.SetFavorite,
            Credential.RequireSessData(), data: data);
    }

    /// <summary>
    ///     同步取消收藏视频（需要 SESSDATA 和 bili_jct 值）
    /// </summary>
    /// <param name="removeMediaIds">需要加入的收藏夹 mlid</param>
    /// <exception cref="BiliNetworkException">网络错误</exception>
    /// <exception cref="BiliOperationException">操作失败</exception>
    /// <returns>收藏结果</returns>
    public BiliVideoSetFavoriteResult RemoveFavorite(IEnumerable<long> removeMediaIds)
    {
        var data = new Dictionary<string, string>
        {
            { "rid", AvId.ToString() },
            { "type", "2" },
            { "del_media_ids", string.Join(",", removeMediaIds) }
        };

        return NetClient.BiliRequest<BiliVideoSetFavoriteResult>(BiliVideoApi.SetFavorite,
            Credential.RequireSessData(), data: data);
    }

    /// <summary>
    ///     同步取消收藏视频（需要 SESSDATA 和 bili_jct 值）
    /// </summary>
    /// <param name="removeMediaIds">需要加入的收藏夹 mlid</param>
    /// <exception cref="BiliNetworkException">网络错误</exception>
    /// <exception cref="BiliOperationException">操作失败</exception>
    /// <returns>收藏结果</returns>
    public async Task<BiliVideoSetFavoriteResult> RemoveFavoriteAsync(IEnumerable<long> removeMediaIds)
    {
        var data = new Dictionary<string, string>
        {
            { "rid", AvId.ToString() },
            { "type", "2" },
            { "del_media_ids", string.Join(",", removeMediaIds) }
        };

        return await NetClient.BiliRequestAsync<BiliVideoSetFavoriteResult>(BiliVideoApi.SetFavorite,
            Credential.RequireSessData(), data: data);
    }

    /// <summary>
    ///     同步取消收藏视频（需要 SESSDATA 和 bili_jct 值）
    /// </summary>
    /// <param name="addMediaIds">需要加入的收藏夹 mlid</param>
    /// <param name="removeMediaIds">需要取消的收藏夹 mlid</param>
    /// <exception cref="BiliNetworkException">网络错误</exception>
    /// <exception cref="BiliOperationException">操作失败</exception>
    /// <returns>收藏结果</returns>
    public BiliVideoSetFavoriteResult SetFavorite(
        IEnumerable<long> addMediaIds, IEnumerable<long> removeMediaIds)
    {
        var data = new Dictionary<string, string>
        {
            { "rid", AvId.ToString() },
            { "type", "2" },
            { "add_media_ids", string.Join(",", addMediaIds) },
            { "del_media_ids", string.Join(",", removeMediaIds) }
        };

        return NetClient.BiliRequest<BiliVideoSetFavoriteResult>(BiliVideoApi.SetFavorite,
            Credential.RequireSessData(), data: data);
    }

    /// <summary>
    ///     同步取消收藏视频（需要 SESSDATA 和 bili_jct 值）
    /// </summary>
    /// <param name="addMediaIds">需要加入的收藏夹 mlid</param>
    /// <param name="removeMediaIds">需要取消的收藏夹 mlid</param>
    /// <exception cref="BiliNetworkException">网络错误</exception>
    /// <exception cref="BiliOperationException">操作失败</exception>
    /// <returns>收藏结果</returns>
    public async Task<BiliVideoSetFavoriteResult> SetFavoriteAsync(
        IEnumerable<long> addMediaIds, IEnumerable<long> removeMediaIds)
    {
        var data = new Dictionary<string, string>
        {
            { "rid", AvId.ToString() },
            { "type", "2" },
            { "add_media_ids", string.Join(",", addMediaIds) },
            { "del_media_ids", string.Join(",", removeMediaIds) }
        };

        return await NetClient.BiliRequestAsync<BiliVideoSetFavoriteResult>(BiliVideoApi.SetFavorite,
            Credential.RequireSessData(), data: data);
    }


    /// <summary>
    ///     同步获取视频是否已收藏（需要 SESSDATA 值）
    /// </summary>
    /// <param name="useAvId">使用 AV 号构造请求</param>
    /// <returns>是否已收藏</returns>
    /// <exception cref="BiliNetworkException">网络错误</exception>
    /// <exception cref="BiliOperationException">操作失败</exception>
    public bool HasFavored(bool useAvId = false)
    {
        var result = NetClient.BiliRequest<BiliVideoHasFavoredResult>(BiliVideoApi.HasFavored,
            Credential.RequireSessData(),
            new QueryBuilder().Add("aid", useAvId ? AvId.ToString() : BvId));
        return result.Favored;
    }

    /// <summary>
    ///     异步获取视频是否已收藏（需要 SESSDATA 值）
    /// </summary>
    /// <param name="useAvId">使用 AV 号构造请求</param>
    /// <returns>是否已收藏</returns>
    /// <exception cref="BiliNetworkException">网络错误</exception>
    /// <exception cref="BiliOperationException">操作失败</exception>
    public async Task<bool> HasFavoredAsync(bool useAvId = false)
    {
        var result = await NetClient.BiliRequestAsync<BiliVideoHasFavoredResult>(BiliVideoApi.HasFavored,
            Credential.RequireSessData(),
            new QueryBuilder().Add("aid", useAvId ? AvId.ToString() : BvId));
        return result.Favored;
    }
    
    
    /// <summary>
    ///     同步三连视频（需要 SESSDATA 和 bili_jct 值）
    /// </summary>
    /// <param name="useAvId">使用 AV 号构造请求</param>
    /// <exception cref="BiliNetworkException">网络错误</exception>
    /// <exception cref="BiliOperationException">操作失败</exception>
    public void SetTriple(bool useAvId = false)
    {
        var data = new Dictionary<string, string>();

        if (useAvId)
            data.Add("aid", AvId.ToString());
        else
            data.Add("bvid", BvId);

        NetClient.BiliRequest(BiliVideoApi.SetTriple, Credential.RequireSessData(),
            data: data);
    }

    /// <summary>
    ///     异步三连视频（需要 SESSDATA 和 bili_jct 值）
    /// </summary>
    /// <param name="useAvId">使用 AV 号构造请求</param>
    /// <exception cref="BiliNetworkException">网络错误</exception>
    /// <exception cref="BiliOperationException">操作失败</exception>
    public async Task SetTripleAsync(bool useAvId = false)
    {
        var data = new Dictionary<string, string>();

        if (useAvId)
            data.Add("aid", AvId.ToString());
        else
            data.Add("bvid", BvId);

        await NetClient.BiliRequestAsync(BiliVideoApi.SetTriple, Credential.RequireSessData(),
            data: data);
    }
}