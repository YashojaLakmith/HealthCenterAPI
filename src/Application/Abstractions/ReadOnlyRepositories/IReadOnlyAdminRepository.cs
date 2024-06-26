using Application.Admin.Views;
using Application.CustomFilters;
using Domain.Common;
using Domain.ValueObjects;

namespace Application.Abstractions.ReadOnlyRepositories;

public interface IReadOnlyAdminRepository
{
    Task<Result<UserDetailView>> GetAdminDetailViewAsync(Id adminId, CancellationToken cancellationToken = default);

    Task<Result<IReadOnlyCollection<UserListItem>>> GetUserListAsync(AdminFilter filter, CancellationToken cancellationToken = default);
}