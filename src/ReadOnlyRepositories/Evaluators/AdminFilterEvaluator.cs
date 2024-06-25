using Application.CustomFilters;
using Domain.Entities;
using Domain.Enum;

namespace ReadOnlyRepositories.Evaluators;

internal static class AdminFilterEvaluator
{
    internal static IQueryable<Admin> EvaluateFilter(this IQueryable<Admin> query, AdminFilter filter)
    {
        query = ApplyPartOfNameFilter(query, filter.PartOfName);
        query = ApplyRoleFilter(query, filter.Role);
        
        return query
            .OrderBy(admin => admin.AdminName.Value)
            .ApplyPagination(filter.Pagination);
    }

    private static IQueryable<Admin> ApplyPartOfNameFilter(IQueryable<Admin> query, string? partOfName)
    {
        return partOfName is null
            ? query
            : query.Where(admin =>
                admin.AdminName.Value.Contains(partOfName, StringComparison.OrdinalIgnoreCase));
    }

    private static IQueryable<Admin> ApplyRoleFilter(IQueryable<Admin> query, Role? role)
    {
        return role is null
            ? query
            : query.Where(admin => admin.Role == role);
    }
}