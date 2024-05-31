using Microsoft.Extensions.Caching.Memory;

using WebAPI.Abstractions.DataStore;
using WebAPI.Abstractions.Secrets;
using WebAPI.Helpers;

namespace WebAPI.Secrets;

public class UserSecretsImpl : IUserSecrets
{
    private const string DBKey = @"DB";
    private const string JWTKey = @"JwtSignKey";

    private readonly IUserSecretCache _secretStore;
    private readonly ICloudSecretStore _cloudStore;
    private readonly IConfiguration _configuration;
    private readonly int _attempts;

    public UserSecretsImpl(IUserSecretCache secretCache, ICloudSecretStore cloudStore, IConfiguration configuration)
    {
        _secretStore = secretCache;
        _cloudStore = cloudStore;
        _configuration = configuration;
        _attempts = GetAttempts();
    }

    public async Task<string> GetDbConnectionStringAsync()
    {
        var entry = _secretStore.Get(DBKey);
        for(var i = 1; i <= _attempts; i++)
        {
            if(entry is not null)
            {
                break;
            }

            await TryRefreshDbConnStringAsync();
            entry = _secretStore.Get(DBKey);
        }

        if(entry is string str)
        {
            return str;
        }

        throw new InvalidOperationException();
    }

    public async Task<byte[]> GetJwtSigningKeyAsync()
    {
        var entry = _secretStore.Get(JWTKey);

        for(var i = 1; i <= _attempts; i++)
        {
            if(entry is not null)
            {
                break;
            }

            await TryRefreshJwtKeyAsync();
            entry = _secretStore.Get(JWTKey);
        }

        if(entry is byte[] bytes)
        {
            return bytes;
        }

        throw new InvalidOperationException();
    }

    private int GetAttempts()
    {
        return _configuration.GetValue(@"SecretStore_Fallback_Attempts", 3);
    }

    private async Task TryRefreshDbConnStringAsync()
    {
        var connString = await _cloudStore.GetDbConnectionStringAsync();
        _secretStore.Set(DBKey, connString);
    }

    private async Task TryRefreshJwtKeyAsync()
    {
        var key = await _cloudStore.GetJwtSigningKeyAsync();
        var bytes = KeyTransform.HexStringAsKey(key);
        _secretStore.Set(JWTKey, bytes);
    }
}

public static class UserSecretExtensions
{
    public static IServiceCollection AddUserSecrets(this IServiceCollection services)
    {
        return services.AddSingleton<IUserSecrets, UserSecretsImpl>();
    }
}
