using Microsoft.Extensions.Caching.Memory;

namespace WebAPI.Abstractions.DataStore;

public interface ILocalSecretCache : IMemoryCache
{
}
