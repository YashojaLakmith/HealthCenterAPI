using Application.CustomFilters;
using Domain.Entities;
using Domain.ValueObjects;

namespace ReadOnlyRepositories.Evaluators;

internal static class SessionByDoctorIdFilterEvaluator
{
    internal static IQueryable<Session> EvaluateFilter(this IQueryable<Session> query, SessionFilterByDoctorId filter)
    {
        query = ApplyDoctorIdFilter(query, filter.DoctorId);
        query = ApplyTimeRangeLowerLimitFilter(query, filter.BeginsAfter);
        query = ApplyTimeRangeUpperLimitFilter(query, filter.EndsBefore);

        return query
            .OrderBy(session => session.SessionSpan.SessionStartValue)
            .ApplyPagination(filter.Pagination);
    }

    private static IQueryable<Session> ApplyDoctorIdFilter(IQueryable<Session> query, Id? doctorId)
    {
        return doctorId is null
            ? query
            : query.Where(session => session.Doctor.Id == doctorId);
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