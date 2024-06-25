using Application.Abstractions.CQRS;
using Application.Appointment.Views;
using Application.Common;
using Domain.Common;
using Domain.Repositories;

namespace Application.Appointment.QueryHandlers;
internal class ViewDetailedAppointmentQueryHandler : IQueryHandler<AppointmentDetailView, IdQuery>
{
    private readonly IAppointmentRepository _appointmentRepository;

    public ViewDetailedAppointmentQueryHandler(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<Result<AppointmentDetailView>> HandleAsync(IdQuery query, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
