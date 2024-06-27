using Application.Abstractions.CQRS;
using Application.Abstractions.ReadOnlyRepositories;
using Application.Common;
using Application.Session.Views;

using Domain.Common;
using Domain.ValueObjects;

namespace Application.Session.QueryHandlers;
internal class ViewSessionDetailsQueryHandler : IQueryHandler<SessionDetailView, IdQuery>
{
    private readonly IReadOnlySessionRepository _sessionRepository;

    public ViewSessionDetailsQueryHandler(IReadOnlySessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public async Task<Result<SessionDetailView>> HandleAsync(IdQuery query, CancellationToken cancellationToken = default)
    {
        var id = Id.CreateId(query.Id);

        return await _sessionRepository.GetSessionDetailViewAsync(id, cancellationToken);
    }
}
