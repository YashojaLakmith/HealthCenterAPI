using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Abstractions.DomainServices;

public interface IDeleteAdminService
{
    Task<Result> DeleteAdminAsync(Id adminId, Id invokerId, CancellationToken cancellationToken = default);
}