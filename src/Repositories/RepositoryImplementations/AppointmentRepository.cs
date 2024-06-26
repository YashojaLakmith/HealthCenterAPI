using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Repositories.RepositoryImplementations;
internal sealed class AppointmentRepository : IAppointmentRepository
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

    public async Task<Result<Appointment>> GetByIdAsync(Id appointmentId, CancellationToken cancellationToken = default)
    {
        var resultSet = await _dbContext.Appointments
                                        .Include(appointment => appointment.Patient)
                                        .Include(appointment => appointment.Session)
                                        .Where(appointment => appointment.Id == appointmentId)
                                        .FirstOrDefaultAsync(cancellationToken);

        return resultSet ?? Result<Appointment>.Failure(RepositoryErrors.NotFoundError);
    }
}
