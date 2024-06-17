using Domain.Common;
using Domain.Entities;
using Domain.Query;
using Domain.ValueObjects;

namespace Domain.Repositories;
public interface IDoctorRepository
{
    Task<Result<List<Doctor>>> GetByFilteredQueryAsync(CustomQuery<Doctor> customQuery, Pagination pagination, CancellationToken cancellationToken = default);

    Task<Result<Doctor>> GetByIdAsync(Id doctorId, CancellationToken cancellationToken = default);

    Task<Result<Doctor>> GetByRegistrationNumberAsync(DoctorRegistrationNumber registrationNumber, CancellationToken cancellationToken = default);

    Task<Result<bool>> IsRegistrationNumberExistsAsync(DoctorRegistrationNumber registrationNumber, CancellationToken cancellationToken = default);

    Task<Result<bool>> IsEmailExistsAsync(EmailAddress registrationNumber, CancellationToken cancellationToken = default);

    Task<Result> DeleteAsync(Doctor doctor, CancellationToken cancellationToken = default);

    Task<Result> CreateNewAsync(Doctor newDoctor, CancellationToken cancellationToken = default);
}
