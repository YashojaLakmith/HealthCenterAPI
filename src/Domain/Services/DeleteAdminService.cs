using Domain.Abstractions.DomainServices;
using Domain.Common;
using Domain.Common.Errors;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Domain.Services;

internal sealed class DeleteAdminService : IDeleteAdminService
{
    private readonly IAdminRepository _adminRepository;

    public DeleteAdminService(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public async Task<Result> DeleteAdminAsync(Id adminId, Id invokerId, CancellationToken cancellationToken = default)
    {
        var adminResult = await _adminRepository.GetByIdAsync(adminId, cancellationToken);
        if (adminResult.IsFailure)
        {
            return adminResult;
        }

        var invokerResult = await _adminRepository.GetByIdAsync(invokerId, cancellationToken);
        if (invokerResult.IsFailure)
        {
            return invokerResult;
        }

        if (adminResult.Value.Role >= invokerResult.Value.Role)
        {
            return Result.Failure(RoleErrors.NotHaveAuthorization);
        }

        return await _adminRepository.DeleteAsync(adminResult.Value, cancellationToken);
    }
}