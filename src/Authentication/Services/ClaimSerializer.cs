using System.Security.Claims;
using System.Text.Json;

namespace Authentication.Services;
internal static class ClaimSerializer
{
    private static readonly JsonSerializerOptions _jsonOptions = new() { };

    internal static async Task<byte[]> SerializeClaimsAsync(IReadOnlyCollection<Claim> claims, CancellationToken cancellationToken = default)
    {
        var keyValues = claims.Select(claim => KeyValuePair.Create(claim.Type, claim.Value));
        using var mem = new MemoryStream();
        await JsonSerializer.SerializeAsync(mem, keyValues, _jsonOptions, cancellationToken);
        return mem.ToArray();
    }

    internal static async Task<List<Claim>> DeserializeClaimsAsync(byte[] serializedClaims, CancellationToken cancellationToken = default)
    {
        var mem = new MemoryStream(serializedClaims);
        var keyValues = await JsonSerializer.DeserializeAsync<IEnumerable<KeyValuePair<string, string>>>(
            mem,
            _jsonOptions,
            cancellationToken: cancellationToken);

        return keyValues.Select(kvp => new Claim(kvp.Key, kvp.Value)).ToList();
    }
}
