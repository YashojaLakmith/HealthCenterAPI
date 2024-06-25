using Application.CustomFilters;
using Domain.Entities;

namespace ReadOnlyRepositories.Evaluators;

internal static class SessionFilterEvaluator
{
    internal static IQueryable<Session> EvaluateFilter(this IQueryable<Session> query, SessionFilter filter)
    {
        query = ApplyDoctorNameFilter(query, filter.PartOfDoctorName);
        query = ApplyTimeRangeLowerLimitFilter(query, filter.BeginsAfter);
        query = ApplyTimeRangeUpperLimitFilter(query, filter.EndsBefore);

        return query
            .OrderBy(session => session.SessionSpan.SessionStartValue)
            .ApplyPagination(filter.Pagination);
    }

    private static IQueryable<Session> ApplyDoctorNameFilter(IQueryable<Session> query, string? partOfName)
    {
        return partOfName is null
            ? query
            : query.Where(session =>
                session.Doctor.DoctorName.Value.Contains(partOfName, StringComparison.OrdinalIgnoreCase));
    }

    private static IQueryable<Session> ApplyTimeRangeLowerLimitFilter(IQueryable<Session> query, DateTime? beginsAfter)
    {
        return beginsAfter is null
            ? query
            : query.Where(session => session.SessionSpan.SessionStartValue > beginsAfter);
    }
    
    private static IQueryable<Session> ApplyTimeRangeUpperLimitFilter(IQueryable<Session> query, DateTime? endsBefore)
    {
        return endsBefore is null
            ? query
            : query.Where(session => session.SessionSpan.SessionEndValue < endsBefore);
    }
}