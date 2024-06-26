using Application.Abstractions.CQRS;
using Application.Abstractions.Factories.Appointment;
using Application.Abstractions.ReadOnlyRepositories;
using Application.Appointment.Queries;
using Application.Appointment.QueryHandlers;
using Application.Appointment.Views;
using Application.Common;
using Domain.Common;

namespace Application.Factories.Appointment;
internal sealed class AppointmentQueryHandlersFactoryImpl : IAppointmentQueryHandlerFactory
{
    private readonly IReadOnlyAppointmentRepository _repository;

    private IQueryHandler<IReadOnlyCollection<AppointmentListItemView>, AppointmentFilterQuery>? _listViewHandler;
    private IQueryHandler<AppointmentDetailView, IdQuery>? _detailViewHandler;

    public AppointmentQueryHandlersFactoryImpl(IReadOnlyAppointmentRepository repository)
    {
        _repository = repository;
    }

    public IQueryHandler<IReadOnlyCollection<AppointmentListItemView>, AppointmentFilterQuery> ViewAppointmentListQueryHandler
        => _listViewHandler ??= new ViewAppointmentListQueryHandler(_repository);

    public IQueryHandler<AppointmentDetailView, IdQuery> ViewAppointmentDetailViewQueryHandler
        => _detailViewHandler ??= new ViewDetailedAppointmentQueryHandler(_repository);
}
