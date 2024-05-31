namespace WebAPI.Auth.JWT;

public class JwtIssueOptions
{
    public string? Issuer { get; set; }
    public string? Audience { get; set; }
    public uint ValidPeriodInMinutes { get; set; }
}
