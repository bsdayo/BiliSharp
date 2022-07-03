using BiliSharp.Models;

namespace BiliSharp;

public abstract class BiliClient
{
    protected HttpClient NetClient { get; }

    public BiliCredential Credential { get; set; }

    protected BiliClient(BiliCredential? credential, HttpClient? httpClient)
    {
        Credential = credential ?? new BiliCredential();
        if (httpClient is not null)
        {
            NetClient = httpClient;
        }
        else
        {
            NetClient = new HttpClient();
            NetClient.DefaultRequestHeaders.Add("User-Agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37");
        }
    }
}