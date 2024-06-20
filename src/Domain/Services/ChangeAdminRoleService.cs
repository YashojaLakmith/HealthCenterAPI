using Domain.Abstractions.DomainServices;
using Domain.Common;
using Domain.Entities;
using Domain.Enum;
using Domain.ValueObjects;

namespace Domain.Services;
public class ChangeAdminRoleService : IChangeAdminRoleService
{
    public Task<Result> ChangeAdminRoleAsync(Admin admin, Id invokerId, Role newRole, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
