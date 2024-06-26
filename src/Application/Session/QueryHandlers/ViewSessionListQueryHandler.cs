using Application.Abstractions.CQRS;
using Application.Abstractions.ReadOnlyRepositories;
using Application.CustomFilters;
using Application.Session.Queries;
using Application.Session.Views;

using Domain.Common;
using Domain.Common.Errors;
using Domain.ValueObjects;

namespace Application.Session.QueryHandlers;
internal class ViewSessionListQueryHandler : IQueryHandler<IReadOnlyCollection<SessionListItemView>, SessionFilterQuery>
{
    private readonly IReadOnlySessionRepository _sessionRepository;

    public ViewSessionListQueryHandler(IReadOnlySessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public async Task<Result<IReadOnlyCollection<SessionListItemView>>> HandleAsync(SessionFilterQuery query, CancellationToken cancellationToken = default)
    {
        var paginationResult = Pagination.Create(query.Pagination.ResultsPerPage, query.Pagination.PageNumber);
        if (paginationResult.IsFailure)
        {
            return Result<IReadOnlyCollection<SessionListItemView>>.Failure(paginationResult.Error);
        }

        if (query.DateTimeRange?.RangeBegin > query.DateTimeRange?.RangeEnd)
        {
            return Result<IReadOnlyCollection<SessionListItemView>>.Failure(TimeRangeErrors.InvalidTimeRange);
        }

        var filter = SessionFilter.CreateFilter(
            paginationResult.Value,
            query.DoctorName,
            query.DateTimeRange?.RangeBegin,
            query.DateTimeRange?.RangeEnd);

        return await _sessionRepository.GetSessionListAsync(filter, cancellationToken);
    }
}
