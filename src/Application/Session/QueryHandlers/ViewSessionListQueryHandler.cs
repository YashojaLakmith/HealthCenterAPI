using Application.Abstractions.CQRS;
using Application.Session.Queries;
using Application.Session.Views;

using Domain.Common;

namespace Application.Session.QueryHandlers;
internal class ViewSessionListQueryHandler : IQueryHandler<IReadOnlyCollection<SessionListItemView>, SessionFilterQuery>
{
    public Task<Result<IReadOnlyCollection<SessionListItemView>>> HandleAsync(SessionFilterQuery query, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
