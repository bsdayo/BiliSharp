using System.Net;
using System.Text.Json;
using BiliSharp.Apis;
using BiliSharp.Models;

namespace BiliSharp.Utils;

internal static class NetUtils
{
    private static HttpRequestMessage ConstructRequest(BiliApi api,
        BiliCredential credential,
        QueryBuilder? query = null, Dictionary<string, string>? data = null)
    {
        var request = new HttpRequestMessage
        {
            Method = api.Method,
            RequestUri = new Uri(query is null ? api.Url : api.Url + query.Build())
        };

        // Referer
        request.Headers.Add("Referer", "https://www.bilibili.com");

        // Cookies
        request.Headers.Add("Cookie", credential.BuildCookie());

        // 添加 CSRF Token
        if (api.Method != HttpMethod.Get)
        {
            data ??= new Dictionary<string, string>();
            data.Add("csrf", credential.RequireBiliJct().BiliJct!);
            data.Add("csrf_token", credential.BiliJct!);
        }

        if (data is not null)
            request.Content = new FormUrlEncodedContent(data);

        return request;
    }

    internal static void BiliRequest(this HttpClient client, BiliApi api,
        BiliCredential credential,
        QueryBuilder? query = null, Dictionary<string, string>? data = null)
    {
        var request = ConstructRequest(api, credential, query, data);

        // 发送请求
        var response = client.Send(request);

        if (response.StatusCode != HttpStatusCode.OK)
            throw new BiliNetworkException(response.StatusCode);

        var result = JsonSerializer.Deserialize<BiliResponse>(
            response.Content.ReadAsStream())!;

        if (result.Code != 0)
            throw new BiliOperationException(result.Code, result.Message);
    }

    internal static T BiliRequest<T>(this HttpClient client, BiliApi api,
        BiliCredential credential,
        QueryBuilder? query = null, Dictionary<string, string>? data = null)
    {
        var request = ConstructRequest(api, credential, query, data);

        // 发送请求
        var response = client.Send(request);

        if (response.StatusCode != HttpStatusCode.OK)
            throw new BiliNetworkException(response.StatusCode);

        var result = JsonSerializer.Deserialize<BiliResponse<T>>(
            response.Content.ReadAsStream())!;

        if (result.Code != 0)
            throw new BiliOperationException(result.Code, result.Message);

        return result.Data;
    }

    internal static async Task BiliRequestAsync(this HttpClient client, BiliApi api,
        BiliCredential credential,
        QueryBuilder? query = null, Dictionary<string, string>? data = null)
    {
        var request = ConstructRequest(api, credential, query, data);

        // 发送请求
        var response = await client.SendAsync(request);

        if (response.StatusCode != HttpStatusCode.OK)
            throw new BiliNetworkException(response.StatusCode);

        var result = JsonSerializer.Deserialize<BiliResponse>(
            await response.Content.ReadAsStringAsync())!;

        if (result.Code != 0)
            throw new BiliOperationException(result.Code, result.Message);
    }

    internal static async Task<T> BiliRequestAsync<T>(this HttpClient client, BiliApi api,
        BiliCredential credential,
        QueryBuilder? query = null, Dictionary<string, string>? data = null)
    {
        var request = ConstructRequest(api, credential, query, data);

        // 发送请求
        var response = await client.SendAsync(request);

        if (response.StatusCode != HttpStatusCode.OK)
            throw new BiliNetworkException(response.StatusCode);

        var result = JsonSerializer.Deserialize<BiliResponse<T>>(
            await response.Content.ReadAsStringAsync())!;

        if (result.Code != 0)
            throw new BiliOperationException(result.Code, result.Message);

        return result.Data;
    }
}

public class BiliNetworkException : BiliException
{
    internal BiliNetworkException(HttpStatusCode statusCode)
        : base($"Request failed with status code {statusCode}")
    {
    }
}

public class BiliOperationException : BiliException
{
    internal BiliOperationException(int errorCode, string message)
        : base($"({errorCode}) {message}")
    {
    }
}