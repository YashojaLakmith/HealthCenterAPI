using System.Security.Claims;
using System.Text.Json;

using Application.Authentication.Abstractions.TokenManagement;

using Authentication.ValueObjects;

using Domain.Common;

using Microsoft.Extensions.Caching.Distributed;

using Web.Abstractions;

namespace Web.Sessions;

public class SessionManager : ISessionManagement
{
    private readonly IDistributedSessionCache _cache;
    private readonly DistributedCacheEntryOptions _options;

    public SessionManager(IDistributedSessionCache cache, DistributedCacheEntryOptions options)
    {
        _cache = cache;
        _options = options;
    }

    public async Task<Result<SessionToken>> CreateSessionAsync(IEnumerable<Claim> claims, CancellationToken cancellationToken = default)
    {
        var newTokenResult = SessionToken.CreateToken();
        var serializedClaims = await SerializeClaimsAsync(claims, cancellationToken);
        await _cache.SetAsync(newTokenResult.Value.Value, serializedClaims, _options, cancellationToken);

        return newTokenResult.Value;
    }

    public async Task<Result<IEnumerable<Claim>>> GetClaimsAsync(SessionToken token, CancellationToken cancellationToken = default)
    {
        var serializedClaims = await _cache.GetAsync(token.Value, cancellationToken);
        if(serializedClaims is null)
        {
            return Result<IEnumerable<Claim>>.Failure(new Exception());
        }

        var claims = DeserializeClaimsAsync(serializedClaims).ToBlockingEnumerable(cancellationToken);
        return Result<IEnumerable<Claim>>.Success(claims);
    }

    public async Task<Result> RefreshSessionAsync(SessionToken sessionToken, CancellationToken cancellationToken = default)
    {
        await _cache.RefreshAsync(sessionToken.Value, cancellationToken);
        return Result.Success();
    }

    public async Task<Result> RevokeSessionAsync(SessionToken sessionToken, CancellationToken cancellationToken = default)
    {
        await _cache.RemoveAsync(sessionToken.Value, cancellationToken);
        return Result.Success();
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
