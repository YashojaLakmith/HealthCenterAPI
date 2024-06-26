using Application.Abstractions.CQRS;
using Application.Abstractions.ReadOnlyRepositories;
using Application.Appointment.Views;
using Application.Common;
using Domain.Common;
using Domain.ValueObjects;

namespace Application.Appointment.QueryHandlers;
internal class ViewDetailedAppointmentQueryHandler : IQueryHandler<AppointmentDetailView, IdQuery>
{
    private readonly IReadOnlyAppointmentRepository _appointmentRepository;

    public ViewDetailedAppointmentQueryHandler(IReadOnlyAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<Result<AppointmentDetailView>> HandleAsync(IdQuery query, CancellationToken cancellationToken = default)
    {
        var idResult = Id.CreateId(query.Id);
        if (idResult.IsFailure)
        {
            return Result<AppointmentDetailView>.Failure(idResult.Error);
        }

        return await _appointmentRepository.GetAppointmentDetailViewAsync(idResult.Value, cancellationToken);
    }
}
