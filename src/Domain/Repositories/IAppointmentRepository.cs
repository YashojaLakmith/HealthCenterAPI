using Domain.Common;
using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Repositories;
public interface IAppointmentRepository
{
    Task<Result<List<Appointment>>> GetByFilteredQueryAsync(Pagination pagination, CancellationToken cancellationToken = default);

    Task<Result<Appointment>> GetByIdAsync(Id appointmentId, CancellationToken cancellationToken = default);

    Task<Result> InsertNewAsync(Appointment appointment, CancellationToken cancellationToken = default);

    Task<Result> DeleteAsync(Id appointmentId, CancellationToken cancellationToken = default);

    Task<Result<bool>> ExistsAsync(Id appointmentId, CancellationToken cancellationToken = default);

    Task<Result<bool>> HasAlredyRegisteredAsync(Id patientId, Id sessionId,  CancellationToken cancellationToken = default);
}
