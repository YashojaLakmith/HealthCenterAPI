using Application.Abstractions.CQRS;
using Application.Admin.Queries;
using Application.Admin.Views;

using Domain.Common;

namespace Application.Admin.QueryHandlers;
internal class UserListQueryHandler : IQueryHandler<IReadOnlyCollection<UserListItem>, UserFilterQuery>
{
    public Task<Result<IReadOnlyCollection<UserListItem>>> HandleAsync(UserFilterQuery query, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
