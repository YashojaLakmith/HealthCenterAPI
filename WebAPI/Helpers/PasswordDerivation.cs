using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace WebAPI.Helpers;

public class PasswordDerivation
{
    private const int PasswordLengthInBytes = 64;
    private const int Iterations = 1000000;
    private const KeyDerivationPrf PRF = KeyDerivationPrf.HMACSHA256;

    public static byte[] DerivePassword(string inputPassword, byte[] salt)
    {
        return KeyDerivation.Pbkdf2(inputPassword, salt, PRF, Iterations, PasswordLengthInBytes);
    }
}
