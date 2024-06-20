using Domain.Common;
using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Repositories;
public interface IAppointmentRepository
{
    Task<Result<Appointment>> GetByIdAsync(Id appointmentId, CancellationToken cancellationToken = default);

    Task<Result> DeleteAsync(Appointment appointment, CancellationToken cancellationToken = default);
}
