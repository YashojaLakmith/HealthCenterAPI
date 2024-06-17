using Microsoft.Extensions.Caching.Distributed;

namespace Web.Abstractions;

public interface IDistributedSessionCache : IDistributedCache
{
}
