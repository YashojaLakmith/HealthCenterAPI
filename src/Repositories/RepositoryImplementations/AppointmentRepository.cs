using Domain.Common;
using Domain.Entities;
using Domain.Query;
using Domain.Repositories;
using Domain.ValueObjects;

using Infrastructure.Abstractions;

using Microsoft.EntityFrameworkCore;

using Repositories.CustomQueries;
using Repositories.Evaluators;

namespace Repositories.RepositoryImplementations;
internal class AppointmentRepository : IAppointmentRepository
{
    private readonly IApplicationDbContext _dbContext;

    public AppointmentRepository(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Result> DeleteAsync(Appointment appointment, CancellationToken cancellationToken = default)
    {
        _dbContext.Appointments.Remove(appointment);
        return Task.FromResult(Result.Success());
    }

    public async Task<Result<List<Appointment>>> GetByFilteredQueryAsync(CustomQuery<Appointment> customQuery, Pagination pagination, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Appointments
                                    .AsNoTracking()
                                    .EvaluateCustomQuery(customQuery)
                                    .ApplyPagination(pagination)
                                    .ToListAsync(cancellationToken);
    }

    public async Task<Result<Appointment>> GetByIdAsync(Id appointmentId, CancellationToken cancellationToken = default)
    {
        var result = await _dbContext.Appointments
                                        .Include(appointment => appointment.Patient)
                                        .Include(appointment => appointment.Session)
                                        .Where(appointment => appointment.Id == appointmentId)
                                        .FirstOrDefaultAsync(cancellationToken);

        if (result is null)
        {
            return Result<Appointment>.Failure(new Exception());
        }

        return result;
    }

    public async Task<Result> InsertNewAsync(Appointment appointment, CancellationToken cancellationToken = default)
    {
        await _dbContext.Appointments.AddAsync(appointment, cancellationToken);
        return Result.Success();
    }
}
