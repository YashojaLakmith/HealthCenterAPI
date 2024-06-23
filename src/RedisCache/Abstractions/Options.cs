using Microsoft.Extensions.Configuration;

namespace DistributedRedisCache.Abstractions;
internal sealed class Options
{
    private readonly IConfiguration _configuration;

    public TimeSpan ResetTokenTimeout { get; }
    public TimeSpan SessionTimeout { get; }

    public Options(IConfiguration configuration)
    {
        _configuration = configuration;

        var timeOutSection = _configuration.GetSection(@"TokenTimeouts");
        var tokenTimeoutMinutes = timeOutSection[@"ResetToken"];
        var sessionTimeoutMinutes = timeOutSection[@"Session"];

        ResetTokenTimeout = TimeSpan.FromMinutes(double.Parse(tokenTimeoutMinutes));
        SessionTimeout = TimeSpan.FromMinutes(double.Parse(sessionTimeoutMinutes));
    }
}
