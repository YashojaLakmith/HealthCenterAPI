using Application.Abstractions.CQRS;
using Application.Abstractions.ReadOnlyRepositories;
using Application.CustomFilters;
using Application.Session.Queries;
using Application.Session.Views;
using Domain.Common;
using Domain.Common.Errors;
using Domain.ValueObjects;

namespace Application.Session.QueryHandlers;

public class ViewSessionListByDoctorQueryHandler : IQueryHandler<IReadOnlyCollection<SessionListItemView>, SessionFilterByDoctorIdQuery>
{
    private readonly IReadOnlySessionRepository _sessionRepository;

    public ViewSessionListByDoctorQueryHandler(IReadOnlySessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public async Task<Result<IReadOnlyCollection<SessionListItemView>>> HandleAsync(
        SessionFilterByDoctorIdQuery query,
        CancellationToken cancellationToken = default)
    {
        var id = query.DoctorId is null ? null : Id.CreateId(query.DoctorId.Value);

        var paginationResult = Pagination.Create(query.Pagination.ResultsPerPage, query.Pagination.PageNumber);
        if (paginationResult.IsFailure)
        {
            return Result<IReadOnlyCollection<SessionListItemView>>.Failure(paginationResult.Error);
        }

        if (query.TimeRange?.RangeBegin > query.TimeRange?.RangeEnd)
        {
            return Result<IReadOnlyCollection<SessionListItemView>>.Failure(TimeRangeErrors.InvalidTimeRange);
        }

        var filter = SessionFilterByDoctorId.CreateFilter(
            paginationResult.Value,
            id,
            query.TimeRange?.RangeBegin,
            query.TimeRange?.RangeEnd);

        return await _sessionRepository.GetSessionListAsync(filter, cancellationToken);
    }
}