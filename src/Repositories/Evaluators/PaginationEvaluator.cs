using Domain.Primitives;
using Domain.ValueObjects;

namespace Repositories.Evaluators;
internal static class PaginationEvaluator
{
    public static IQueryable<TEntity> ApplyPagination<TEntity>(this IQueryable<TEntity> queryable, Pagination pagination) where TEntity : Entity
    {
        (var skip, var take) = Evaluate(pagination);

        return queryable.Skip(skip).Take(take);
    }
    private static (int skip, int take) Evaluate(Pagination pagination)
    {
        return ((pagination.PageNumberValue - 1) * pagination.ResultsPerPageValue, pagination.ResultsPerPageValue);
    }
}
