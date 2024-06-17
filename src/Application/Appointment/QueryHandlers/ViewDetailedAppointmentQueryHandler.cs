using Application.Abstractions.CQRS;
using Application.Appointment.Views;
using Application.Common;

using Domain.Common;

namespace Application.Appointment.QueryHandlers;
internal class ViewDetailedAppointmentQueryHandler : IQueryHandler<AppointmentDetailView, IdCommandQuery>
{
    public Task<Result<AppointmentDetailView>> HandleAsync(IdCommandQuery query, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
