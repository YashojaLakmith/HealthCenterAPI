using Microsoft.Extensions.Caching.Distributed;

namespace WebAPI.Abstractions.Caching;

public interface ISessionCache : IDistributedCache
{
}
