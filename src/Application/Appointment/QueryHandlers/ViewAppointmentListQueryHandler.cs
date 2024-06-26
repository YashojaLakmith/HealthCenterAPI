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
        var idResult = query.PatientId is null
            ? null
            : Id.CreateId(query.PatientId.Value);

        if (idResult is not null && idResult.IsFailure)
        {
            return Result<IReadOnlyCollection<AppointmentListItemView>>.Failure(idResult.Error);
        }

        var paginationResult = Pagination.Create(query.Pagination.ResultsPerPage, query.Pagination.PageNumber);
        if (paginationResult.IsFailure)
        {
            return Result<IReadOnlyCollection<AppointmentListItemView>>.Failure(paginationResult.Error);
        }

        var filter = AppointmentFilter.CreateFilter(
            paginationResult.Value,
            idResult?.Value,
            query.AppointmentStatus);

        return await _appointmentRepository.GetAppointmentListAsync(filter, cancellationToken);
    }
}
