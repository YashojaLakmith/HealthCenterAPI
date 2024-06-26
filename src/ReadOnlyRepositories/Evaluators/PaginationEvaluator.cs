using Domain.ValueObjects;

namespace ReadOnlyRepositories.Evaluators;

internal static class PaginationEvaluator
{
    internal static IQueryable<T> ApplyPagination<T>(this IQueryable<T> query, Pagination pagination)
    {
        var skip = (pagination.PageNumberValue - 1) * pagination.ResultsPerPageValue;

        return query
            .Skip(skip)
            .Take(pagination.ResultsPerPageValue);
    }
}