using System.Security.Cryptography;
using System.Text;

namespace Authentication.Services;
internal static class PasswordDerivation
{
    private const int Iterations = 100000;
    private const int HashBitLength = 256;
    private const int SaltBitLength = 256;
    private const int RandomStringLength = 14;

    internal static byte[] DerivePassword(string plainText, byte[] salt)
    {
        var bytes = Encoding.UTF8.GetBytes(plainText);
        return Rfc2898DeriveBytes.Pbkdf2(bytes, salt, Iterations, HashAlgorithmName.SHA256, HashBitLength);
    }

    internal static byte[] DeriveNewSalt()
    {
        return RandomNumberGenerator.GetBytes(SaltBitLength / 8);
    }

    internal static string DeriveRandomPasswordString()
    {
        return RandomNumberGenerator.GetHexString(RandomStringLength, true);
    }
}
