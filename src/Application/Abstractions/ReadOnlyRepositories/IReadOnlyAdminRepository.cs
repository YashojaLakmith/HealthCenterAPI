using Application.Admin.Views;
using Application.CustomFilters;
using Domain.Common;
using Domain.ValueObjects;

namespace Application.Abstractions.ReadOnlyRepositories;

public interface IReadOnlyAdminRepository
{
    Task<Result<AdminDetailView>> GetAdminDetailViewAsync(Id adminId, CancellationToken cancellationToken = default);

    Task<Result<IReadOnlyCollection<AdminListItem>>> GetAdminListAsync(AdminFilter filter, CancellationToken cancellationToken = default);
}