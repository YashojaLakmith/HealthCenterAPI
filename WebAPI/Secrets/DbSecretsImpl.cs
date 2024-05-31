using Microsoft.Extensions.Caching.Memory;

using SecretStore.Abstractions;

using WebAPI.Abstractions.DataStore;

namespace WebAPI.Secrets;

public class DbSecretsImpl : IDatabaseSecrets
{
    private readonly ILocalSecretCache _localCache;
    private readonly ICloudSecretStore _cloudStore;
    private readonly IConfiguration _configuration;
    private readonly int _attempts;

    public DbSecretsImpl(ILocalSecretCache localCache, ICloudSecretStore cloudStore, IConfiguration configuration)
    {
        _localCache = localCache;
        _cloudStore = cloudStore;
        _configuration = configuration;
        _attempts = GetAttempts();
    }

    public async Task<string> GetDbConnectionStringAsync()
    {
        for (var i = 0; i < _attempts; i++)
        {
            var entry = _localCache.Get(SecretKeyNames.DBKey);
            if (entry is string str)
            {
                return str;
            }

            await TryRefreshDbConnStringAsync();
        }

        throw new InvalidOperationException();
    }

    private int GetAttempts()
    {
        return _configuration.GetValue(@"SecretStore_Fallback_Attempts", 3);
    }

    private async Task TryRefreshDbConnStringAsync()
    {
        var entry = await _cloudStore.GetSecretAsync(SecretKeyNames.DBKey);
        _localCache.Set(SecretKeyNames.DBKey, entry);
    }
}

public static class DbSecretsExtensions
{
    public static IServiceCollection AddDbSecrets(this IServiceCollection services)
    {
        return services.AddSingleton<IDatabaseSecrets, DbSecretsImpl>();
    }
}
