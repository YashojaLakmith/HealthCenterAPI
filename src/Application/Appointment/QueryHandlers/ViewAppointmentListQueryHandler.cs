using Application.Abstractions.CQRS;
using Application.Abstractions.ReadOnlyRepositories;
using Application.Appointment.Queries;
using Application.Appointment.Views;
using Application.CustomFilters;
using Domain.Common;
using Domain.ValueObjects;

namespace Application.Appointment.QueryHandlers;
internal class ViewAppointmentListQueryHandler : IQueryHandler<IReadOnlyCollection<AppointmentListItemView>, AppointmentFilterQuery>
{
    private readonly IReadOnlyAppointmentRepository _appointmentRepository;

    public ViewAppointmentListQueryHandler(IReadOnlyAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<Result<IReadOnlyCollection<AppointmentListItemView>>> HandleAsync(
        AppointmentFilterQuery query,
        CancellationToken cancellationToken = default)
    {
        var id = query.PatientId is null
            ? null
            : Id.CreateId(query.PatientId.Value);

        var paginationResult = Pagination.Create(query.Pagination.ResultsPerPage, query.Pagination.PageNumber);
        if (paginationResult.IsFailure)
        {
            return Result<IReadOnlyCollection<AppointmentListItemView>>.Failure(paginationResult.Error);
        }

        var filter = AppointmentFilter.CreateFilter(
            paginationResult.Value,
            id,
            query.AppointmentStatus);

        return await _appointmentRepository.GetAppointmentListAsync(filter, cancellationToken);
    }
}
