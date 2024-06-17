using Application.Abstractions.CQRS;
using Application.Common;
using Application.User.Views;

using Domain.Common;

namespace Application.User.QueryHandlers;
internal class UserDetailViewQueryHandler : IQueryHandler<UserDetailView, IdCommandQuery>
{
    public Task<Result<UserDetailView>> HandleAsync(IdCommandQuery query, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
