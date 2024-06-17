using Domain.Primitives;
using Domain.Query;

namespace Repositories.CustomQueries;
internal static class CustomQueryEvaluator
{
    public static IQueryable<TEntity> EvaluateCustomQuery<TEntity>(this IQueryable<TEntity> queryable, CustomQuery<TEntity> customQuery) where TEntity : Entity
    {
        throw new NotImplementedException();
    }
}
