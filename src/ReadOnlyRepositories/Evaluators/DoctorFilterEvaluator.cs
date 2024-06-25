using Application.CustomFilters;
using Domain.Entities;

namespace ReadOnlyRepositories.Evaluators;

internal static class DoctorFilterEvaluator
{
    internal static IQueryable<Doctor> EvaluateFiter(this IQueryable<Doctor> query, DoctorFilter filter)
    {
        query = ApplyNamePartFilter(query, filter.PartOfName);
        query = query.OrderBy(doc => doc.DoctorName.Value);

        return query
            .OrderBy(doctor => doctor.DoctorName.Value)
            .ApplyPagination(filter.Pagination);
    }

    private static IQueryable<Doctor> ApplyNamePartFilter(IQueryable<Doctor> query, string? partOfName)
    {
        return partOfName is null
            ? query
            : query.Where(doc => doc.DoctorName.Value.Contains(partOfName, StringComparison.OrdinalIgnoreCase));
    }
}