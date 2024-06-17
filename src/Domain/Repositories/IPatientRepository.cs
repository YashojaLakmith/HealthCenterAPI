using Domain.Common;
using Domain.Entities;
using Domain.Query;
using Domain.ValueObjects;

namespace Domain.Repositories;
public interface IPatientRepository
{
    Task<Result<List<Patient>>> GetByFilteredQueryAsync(CustomQuery<Patient> customQuery, Pagination pagination, CancellationToken cancellationToken = default);

    Task<Result<Patient>> GetByIdAsync(Id patientId, CancellationToken cancellationToken = default);

    Task<Result<bool>> IsEmailExistsAsync(EmailAddress registrationNumber, CancellationToken cancellationToken = default);

    Task<Result<bool>> IsNICExistsAsync(NIC nic, CancellationToken cancellationToken = default);

    Task<Result> InsertNewAsync(Patient newPatient, CancellationToken cancellationToken = default);

    Task<Result> DeleteAsync(Patient patient, CancellationToken cancellationToken = default);
}
