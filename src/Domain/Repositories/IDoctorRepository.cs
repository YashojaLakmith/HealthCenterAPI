using Domain.Common;
using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Repositories;
public interface IDoctorRepository
{
    Task<Result<List<Doctor>>> GetByFilteredQueryAsync(Pagination pagination, CancellationToken cancellationToken = default);

    Task<Result<Doctor>> GetByIdAsync(Id doctorId, CancellationToken cancellationToken = default);

    Task<Result<Doctor>> GetByRegistrationNumberAsync(DoctorRegistrationNumber registrationNumber, CancellationToken cancellationToken = default);

    Task<Result> DeleteAsync(Id doctorId, CancellationToken cancellationToken = default);

    Task<Result> ModifyAsync(Doctor doctor, CancellationToken cancellationToken = default);

    Task<Result> CreateNewAsync(Doctor newDoctor, CancellationToken cancellationToken = default);

    Task<Result<bool>> ExistsAsync(Id doctorId, CancellationToken cancellationToken = default);
}
