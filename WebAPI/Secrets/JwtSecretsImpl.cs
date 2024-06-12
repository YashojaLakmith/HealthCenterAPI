using Microsoft.Extensions.Caching.Memory;

using WebAPI.Abstractions.DataStore;
using WebAPI.Abstractions.Secrets;
using WebAPI.Helpers;

namespace WebAPI.Secrets;

public class JwtSecretsImpl : IJwtSecrets
{
    private readonly ILocalSecretCache _localCache;
    private readonly ICloudSecretStore _cloudStore;
    private readonly IConfiguration _configuration;
    private readonly int _attempts;

    public JwtSecretsImpl(ILocalSecretCache localCache, ICloudSecretStore cloudStore, IConfiguration configuration)
    {
        _localCache = localCache;
        _cloudStore = cloudStore;
        _configuration = configuration;
        _attempts = GetAttempts();
    }

    public async Task<byte[]> GetJwtSigningKeyAsync()
    {
        for(var i = 0; i < _attempts; i++)
        {
            var entry = _localCache.Get(SecretKeyNames.JwtKey);
            if (entry is string str)
            {
                return KeyTransform.HexStringAsKey(str);
            }

            await TryRefreshJwtKeyAsync();
        }

        throw new InvalidOperationException();
    }

    private int GetAttempts()
    {
        return _configuration.GetValue(@"SecretStore_Fallback_Attempts", 3);
    }

    private async Task TryRefreshJwtKeyAsync()
    {
        var key = await _cloudStore.GetSecretAsync(SecretKeyNames.JwtKey);
        var bytes = KeyTransform.HexStringAsKey(key);
        _localCache.Set(SecretKeyNames.JwtKey, bytes);
    }
}

public static class JwtSecretsExtensions
{
    public static IServiceCollection AddJwtSecrets(this IServiceCollection services)
    {
        return services.AddSingleton<IJwtSecrets, JwtSecretsImpl>();
    }
}
