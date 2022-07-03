namespace BiliSharp.Utils;

public static class BiliUtils
{
    private const string BvCodeTable = "fZodR9XQDSUm21yCkr6zBqiveYah8bt4xsWpHnJE7jL5VG3guMTKNPAwcF";
    private const long BvAdd = 8728348608L;
    private const long BvXor = 177451812L;
    private static readonly byte[] BvSed = { 11, 10, 3, 8, 4, 6 };
    private static readonly Dictionary<char, byte> BvChars = InitBvChars();

    public static string Av2Bv(long avid)
    {
        var x = (avid ^ BvXor) + BvAdd;
        var r = "BV1  4 1 7  ".ToCharArray();
        for (var i = 0; i < 6; i++)
            r[BvSed[i]] = BvCodeTable[(byte)(x / Math.Pow(58, i) % 58)];
        return new string(r);
    }

    public static long Bv2Av(string bvid)
    {
        var r = 0L;
        for (var i = 0; i < 6; i++)
            r += BvChars[bvid[BvSed[i]]] * (long)Math.Pow(58, i);
        return (r - BvAdd) ^ BvXor;
    }

    private static Dictionary<char, byte> InitBvChars()
    {
        var chars = new Dictionary<char, byte>();
        for (byte i = 0; i < 58; i++)
            chars.Add(BvCodeTable[i], i);
        return chars;
    }
}