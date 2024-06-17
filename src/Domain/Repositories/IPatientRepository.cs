using Domain.Common;
using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Repositories;
public interface IPatientRepository
{
    Task<Result<List<Patient>>> GetByFilteredQueryAsync(Pagination pagination, CancellationToken cancellationToken = default);

    Task<Result<Patient>> GetByIdAsync(Id patientId, CancellationToken cancellationToken = default);

    Task<Result<Patient>> GetByNICAsync(NIC nic, CancellationToken cancellationToken = default);

    Task<Result> InsertNewAsync(Patient newPatient, CancellationToken cancellationToken = default);

    Task<Result> DeleteAsync(Id patientId, CancellationToken cancellationToken = default);

    Task<Result> ModifyAsync(Patient patient, CancellationToken cancellationToken = default);

    Task<Result<bool>> ExistsByIdAsync(Id patientId, CancellationToken cancellationToken = default);

    Task<Result<bool>> ExistsByNICAsync(Id patientId, CancellationToken cancellationToken = default);
}
