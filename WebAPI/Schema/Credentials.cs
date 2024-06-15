using System.Security.Cryptography;

using Microsoft.EntityFrameworkCore;

using WebAPI.Helpers;

namespace WebAPI.Schema;

[Keyless]
public class Credentials
{
    public byte[] PasswordHash { get; set; }
    public byte[] Salt { get; set; }
    public DateTime LastLogin { get; set; }

    public IndependentPatient Patient { get; set; }
    public EmployeeBase Employee { get; set; }

    public bool IsPasswordCorrect(string password)
    {
        var pw = PasswordDerivation.DerivePassword(password, Salt);
        return pw.SequenceEqual(PasswordHash);
    }

    public void ChangePassword(string password)
    {
        var len = Salt.Length;
        Salt = RandomNumberGenerator.GetBytes(len);
        PasswordHash = PasswordDerivation.DerivePassword(password, Salt);
    }
}
