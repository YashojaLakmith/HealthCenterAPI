using Domain.Common;
using Domain.Entities;
using Domain.Query;
using Domain.ValueObjects;

namespace Domain.Repositories;
public interface IAppointmentRepository
{
    Task<Result<List<Appointment>>> GetByFilteredQueryAsync(CustomQuery<Appointment> customQuery, Pagination pagination, CancellationToken cancellationToken = default);

    Task<Result<Appointment>> GetByIdAsync(Id appointmentId, CancellationToken cancellationToken = default);

    Task<Result> InsertNewAsync(Appointment appointment, CancellationToken cancellationToken = default);

    Task<Result> DeleteAsync(Appointment appointment, CancellationToken cancellationToken = default);
}
