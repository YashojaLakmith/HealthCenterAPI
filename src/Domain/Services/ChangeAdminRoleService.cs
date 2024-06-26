using Domain.Abstractions.DomainServices;
using Domain.Common;
using Domain.Common.Errors;
using Domain.Entities;
using Domain.Enum;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Domain.Services;
internal sealed class ChangeAdminRoleService : IChangeAdminRoleService
{
    private readonly IAdminRepository _adminRepository;

    public ChangeAdminRoleService(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public async Task<Result> ChangeAdminRoleAsync(Admin admin, Id invokerId, Role newRole, CancellationToken cancellationToken = default)
    {
        var invokingAdminRoleReult = await _adminRepository.GetRolesAsync(invokerId, cancellationToken);
        if (invokingAdminRoleReult.IsFailure)
        {
            return invokingAdminRoleReult;
        }

        if(invokingAdminRoleReult.Value > newRole)
        {
            return Result.Failure(RoleErrors.NotHaveAuthorization);
        }

        admin.ChangeRole(newRole);
        return Result.Success();
    }
}
