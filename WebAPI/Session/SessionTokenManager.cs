using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.Json;

using Microsoft.Extensions.Caching.Distributed;
using WebAPI.Abstractions.Caching;
using WebAPI.Abstractions.Session;

namespace WebAPI.Session;

public class SessionTokenManager : ISessionManager
{
    private readonly DistributedCacheEntryOptions _cacheOptions;
    private readonly ISessionCache _sessionCache;
    private readonly SessionTokenOptions _sessionOptions;

    public SessionTokenManager(ISessionCache sessionCache, SessionTokenOptions options)
    {
        _cacheOptions = new();
        _sessionCache = sessionCache;
        _sessionOptions = options;
        _cacheOptions.SlidingExpiration = _sessionOptions.SlidingExpirationTime;
    }

    public async Task<string> CreateTokenAsync(IEnumerable<Claim> claims)
    {
        var id = CreateId();
        var token = await SerializeClaimsAsync(claims);
        await _sessionCache.SetAsync(id, token, _cacheOptions);
        return id;
    }

    public async Task<IEnumerable<Claim>?> GetClaimsAsync(string token)
    {
        var payload = await _sessionCache.GetAsync(token);
        return payload is null ? null : await DeserializeClaimsAsync(payload);
    }

    public async Task RevokeTokenAsync(string token)
    {
        await _sessionCache.RemoveAsync(token);
    }

    private string CreateId()
    {
        var length = RandomNumberGenerator.GetInt32((int)_sessionOptions.MinTokenLengthInBytes, (int)_sessionOptions.MaxTokenLengthInBytes + 1);
        return Convert.ToHexString(RandomNumberGenerator.GetBytes(length));
    }

    private static async Task<byte[]> SerializeClaimsAsync(IEnumerable<Claim> claims)
    {
        var dict = new Dictionary<string, string>();
        foreach (var claim in claims)
        {
            dict.Add(claim.Type, claim.Value);
        }

        using var mem = new MemoryStream();
        await JsonSerializer.SerializeAsync(mem, dict);
        return mem.ToArray();
    }

    private static async Task<IEnumerable<Claim>> DeserializeClaimsAsync(byte[] bytes)
    {
        using var mem = new MemoryStream(bytes);
        var claimDict = await JsonSerializer.DeserializeAsync<Dictionary<string, string>>(mem);

        return claimDict is null ? throw new InvalidDataException() : claimDict.Select(c => new Claim(c.Key, c.Value));
    }
}

public static class SessionManagerExtensions
{
    public static void AddTokenBasedSessions(this IServiceCollection services, Action<SessionTokenOptions> configure)
    {
        var options = new SessionTokenOptions();
        configure(options);
        services.AddSingleton<ISessionManager>(container =>
        {
            var cache = container.GetRequiredService<ISessionCache>();

            return new SessionTokenManager(cache, options);
        });
    }
}