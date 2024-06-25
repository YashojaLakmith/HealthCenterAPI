using Application.Abstractions.ReadOnlyRepositories;
using Application.Appointment.Views;
using Application.CustomFilters;
using Domain.Common;
using Domain.Repositories;
using Domain.ValueObjects;
using Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;
using ReadOnlyRepositories.Evaluators;
using ReadOnlyRepositories.Extensions;

namespace ReadOnlyRepositories.Implementations;

internal sealed class ReadOnlyAppointmentRepository : IReadOnlyAppointmentRepository
{
    private readonly IApplicationDbContext _dbContext;

    public ReadOnlyAppointmentRepository(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<AppointmentDetailView>> GetAppointmentDetailViewAsync(Id appointmentId, CancellationToken cancellationToken = default)
    {
        var queryResult = await _dbContext.Appointments
            .AsNoTracking()
            .Include(appointment => appointment.Patient)
            .Include(appointment => appointment.Session)
            .Where(appointment => appointment.Id == appointmentId)
            .Select(appointment => appointment.AsDetailView())
            .FirstOrDefaultAsync(cancellationToken);

        return queryResult ?? Result<AppointmentDetailView>.Failure(RepositoryErrors.NotFoundError);
    }

    public async Task<Result<IReadOnlyCollection<AppointmentListItemView>>> GetAppointmentListAsync(AppointmentFilter filter, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Appointments
            .AsNoTracking()
            .Include(appointment => appointment.Patient)
            .Include(appointment => appointment.Session)
            .EvaluateAppointmentFilter(filter)
            .Select(appointment => appointment.AsListItem())
            .ToListAsync(cancellationToken); ;
    }
}