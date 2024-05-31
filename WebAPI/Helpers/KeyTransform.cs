namespace WebAPI.Helpers;

public static class KeyTransform
{
    public static string KeyAsHexString(byte[] key)
    {
        return Convert.ToHexString(key);
    }

    public static byte[] HexStringAsKey(string key)
    {
        return Convert.FromHexString(key);
    }
}
