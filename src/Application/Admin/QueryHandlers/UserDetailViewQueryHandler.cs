using Application.Abstractions.CQRS;
using Application.Common;
using Application.Admin.Views;

using Domain.Common;

namespace Application.Admin.QueryHandlers;
internal class UserDetailViewQueryHandler : IQueryHandler<UserDetailView, IdQuery>
{
    public Task<Result<UserDetailView>> HandleAsync(IdQuery query, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
