using Application.Abstractions.CQRS;
using Application.Abstractions.Factories.Appointment;
using Application.Appointment.Queries;
using Application.Appointment.Views;
using Application.Common;

namespace Application.Factories.Appointment;
public class AppointmentQueryHandlersFactoryImpl : IAppointmentQueryHandlerFactory
{
    public IQueryHandler<IReadOnlyCollection<AppointmentListItemView>, AppointmentFilterQuery> ViewAppointmentListQueryHandler
        => throw new NotImplementedException();
    public IQueryHandler<AppointmentDetailView, IdCommandQuery> ViewAppointmentDetailViewQueryHandler
        => throw new NotImplementedException();
}
