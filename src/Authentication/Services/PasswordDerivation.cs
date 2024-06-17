using System.Security.Cryptography;
using System.Text;

namespace Authentication.Services;
internal static class PasswordDerivation
{
    internal static byte[] DerivePassword(string plainText, byte[] salt, int bitLength, int iterations)
    {
        var bytes = Encoding.UTF8.GetBytes(plainText);
        return Rfc2898DeriveBytes.Pbkdf2(bytes, salt, iterations, HashAlgorithmName.SHA256, bitLength);
    }
}
