using Application.Abstractions.CQRS;
using Application.Appointment.Queries;
using Application.Appointment.Views;
using Application.Common;

namespace Application.Abstractions.Factories.Appointment;
public interface IAppointmentQueryHandlerFactory
{
    IQueryHandler<IReadOnlyCollection<AppointmentListItemView>, AppointmentFilterQuery> ViewAppointmentListQueryHandler { get; }

    IQueryHandler<AppointmentDetailView, IdQuery> ViewAppointmentDetailViewQueryHandler { get; }
}
