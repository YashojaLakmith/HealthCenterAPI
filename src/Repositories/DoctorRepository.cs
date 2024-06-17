using Domain.Common;
using Domain.Entities;
using Domain.Query;
using Domain.Repositories;
using Domain.ValueObjects;

using Infrastructure;

using Microsoft.EntityFrameworkCore;

using Repositories.CustomQueries;
using Repositories.Evaluators;

namespace Repositories;
internal class DoctorRepository : IDoctorRepository
{
    private readonly ApplicationDbContext _dbContext;

    public DoctorRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result> CreateNewAsync(Doctor newDoctor, CancellationToken cancellationToken = default)
    {
        await _dbContext.Doctors.AddAsync(newDoctor, cancellationToken);
        return Result.Success();
    }

    public Task<Result> DeleteAsync(Doctor doctor, CancellationToken cancellationToken = default)
    {
        _dbContext.Doctors.Remove(doctor);
        return Task.FromResult(Result.Success());
    }

    public async Task<Result<List<Doctor>>> GetByFilteredQueryAsync(CustomQuery<Doctor> customQuery, Pagination pagination, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Doctors
                                .AsNoTracking()
                                .EvaluateCustomQuery(customQuery)
                                .ApplyPagination(pagination)
                                .ToListAsync(cancellationToken);
    }

    public async Task<Result<Doctor>> GetByIdAsync(Id doctorId, CancellationToken cancellationToken = default)
    {
        var result = await _dbContext.Doctors
                                    .Include(doc => doc.Sessions)
                                    .Where(doc => doc.Id == doctorId)
                                    .FirstOrDefaultAsync(cancellationToken);

        if(result is null)
        {
            return Result<Doctor>.Failure(new Exception());
        }

        return result;
    }

    public async Task<Result<Doctor>> GetByRegistrationNumberAsync(DoctorRegistrationNumber registrationNumber, CancellationToken cancellationToken = default)
    {
        var result = await _dbContext.Doctors
                                    .Include(doc => doc.Sessions)
                                    .Where(doc => doc.RegistrationNumber == registrationNumber)
                                    .FirstOrDefaultAsync(cancellationToken);

        if (result is null)
        {
            return Result<Doctor>.Failure(new Exception());
        }

        return result;
    }
}
