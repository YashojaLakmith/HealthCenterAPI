using Application.Abstractions.CQRS;
using Application.Appointment.Views;
using Application.Common;
using Application.Extensions;

using Domain.Common;
using Domain.Repositories;
using Domain.ValueObjects;

using Microsoft.Extensions.Logging;

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
        cancellationToken.ThrowIfCancellationRequested();

        var idResult = Id.CreateId(query.Id);

        var appointmentResult = await _appointmentRepository.GetByIdAsync(idResult.Value, cancellationToken);
        if (appointmentResult.IsFailure)
        {
            return Result<AppointmentDetailView>.Failure(appointmentResult.Error);
        }

        return appointmentResult.Value.AsDetailView();
    }
}
