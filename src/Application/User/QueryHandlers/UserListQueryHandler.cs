using Application.Abstractions.CQRS;
using Application.User.Queries;
using Application.User.Views;

using Domain.Common;

namespace Application.User.QueryHandlers;
internal class UserListQueryHandler : IQueryHandler<IReadOnlyCollection<UserListItem>, UserFilterQuery>
{
    public Task<Result<IReadOnlyCollection<UserListItem>>> HandleAsync(UserFilterQuery query, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
