using Application.Abstractions.CQRS;
using Application.Common;
using Application.Session.Views;

using Domain.Common;

namespace Application.Session.QueryHandlers;
internal class ViewSessionDetailsQueryHandler : IQueryHandler<SessionDetailView, IdCommandQuery>
{
    public Task<Result<SessionDetailView>> HandleAsync(IdCommandQuery query, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
