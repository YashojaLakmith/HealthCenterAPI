using Application.Appointment.Views;
using Application.CustomFilters;
using Domain.Common;
using Domain.ValueObjects;

namespace Application.Abstractions.ReadOnlyRepositories;

public interface IReadOnlyAppointmentRepository
{
    Task<Result<AppointmentDetailView>> GetAppointmentDetailViewAsync(Id appointmentId, CancellationToken cancellationToken = default);
    
    Task<Result<IReadOnlyCollection<AppointmentListItemView>>> GetAppointmentListAsync(
        AppointmentFilter filter,
        CancellationToken cancellationToken = default);
}