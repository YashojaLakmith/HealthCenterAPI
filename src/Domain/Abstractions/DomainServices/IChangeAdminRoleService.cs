using Domain.Common;
using Domain.Entities;
using Domain.Enum;
using Domain.ValueObjects;

namespace Domain.Abstractions.DomainServices;
public interface IChangeAdminRoleService
{
    Task<Result> ChangeAdminRoleAsync(Admin admin, Id invokerId, Role newRole, CancellationToken cancellationToken = default);
}