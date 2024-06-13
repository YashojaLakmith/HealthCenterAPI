using Microsoft.EntityFrameworkCore;

namespace WebAPI.Schema;

[Keyless]
public class Credentials
{
    public byte[] PasswordHash { get; set; }
    public byte[] Salt { get; set; }
    public DateTime LastLogin { get; set; }

    public UserBase User { get; set; }
}
