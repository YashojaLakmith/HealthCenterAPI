using Application.Abstractions.CQRS;
using Application.Appointment.Queries;
using Application.Appointment.Views;

using Domain.Common;

namespace Application.Appointment.QueryHandlers;
internal class ViewAppointmentListQueryHandler : IQueryHandler<IReadOnlyCollection<AppointmentListItemView>, AppointmentFilterQuery>
{
    public Task<Result<IReadOnlyCollection<AppointmentListItemView>>> HandleAsync(AppointmentFilterQuery query, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
