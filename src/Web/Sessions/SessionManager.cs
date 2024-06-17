using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.Json;

using Application.Abstractions.SessionManagement;

using Domain.Common;

using Microsoft.Extensions.Caching.Distributed;

using Web.Abstractions;

namespace Web.Sessions;

public class SessionManager : ISessionManagement
{
    private const int TokenByteLength = 64;

    private readonly IDistributedSessionCache _cache;
    private readonly DistributedCacheEntryOptions _options;

    public SessionManager(IDistributedSessionCache cache, DistributedCacheEntryOptions options)
    {
        _cache = cache;
        _options = options;
    }

    public async Task<Result<string>> CreateSessionAsync(IEnumerable<Claim> claims, CancellationToken cancellationToken = default)
    {
        var token = CreateToken();
        var serializedClaims = await SerializeClaimsAsync(claims, cancellationToken);
        await _cache.SetAsync(token, serializedClaims, _options, cancellationToken);

        return token;
    }

    public async Task<Result<IEnumerable<Claim>>> GetClaimsAsync(string token, CancellationToken cancellationToken = default)
    {
        var serializedClaims = await _cache.GetAsync(token, cancellationToken);
        if(serializedClaims is null)
        {
            return Result<IEnumerable<Claim>>.Failure(new Exception());
        }

        var claims = DeserializeClaimsAsync(serializedClaims).ToBlockingEnumerable(cancellationToken);
        return Result<IEnumerable<Claim>>.Success(claims);
    }

    public async Task<Result> RefreshSessionAsync(string sessionToken, CancellationToken cancellationToken = default)
    {
        await _cache.RefreshAsync(sessionToken, cancellationToken);
        return Result.Success();
    }

    public async Task<Result> RevokeSessionAsync(string sessionToken, CancellationToken cancellationToken = default)
    {
        await _cache.RemoveAsync(sessionToken, cancellationToken);
        return Result.Success();
    }

    private static string CreateToken()
    {
        return RandomNumberGenerator.GetHexString(TokenByteLength * 2);
    }

    private static async Task<byte[]> SerializeClaimsAsync(IEnumerable<Claim> claims, CancellationToken cancellationToken = default)
    {
        var list = new List<KeyValuePair<string, string>>();

        foreach (var claim in claims)
        {
            list.Add(KeyValuePair.Create(claim.Type, claim.Value));
        }

        using var mem = new MemoryStream();
        await JsonSerializer.SerializeAsync(mem, list, cancellationToken: cancellationToken);

        return mem.ToArray();
    }

    private static async IAsyncEnumerable<Claim> DeserializeClaimsAsync(byte[] serialized)
    {
        using var mem = new MemoryStream(serialized);
        var collection = await JsonSerializer.DeserializeAsync<IEnumerable<KeyValuePair<string, string>>>(mem);

        foreach(var kvp in collection)
        {
            yield return new Claim(kvp.Key, kvp.Value);
        }
    }
}
