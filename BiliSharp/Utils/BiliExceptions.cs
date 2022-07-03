namespace BiliSharp.Utils;

public class BiliException : Exception
{
    protected BiliException(string message)
        : base(message)
    {
    }
}