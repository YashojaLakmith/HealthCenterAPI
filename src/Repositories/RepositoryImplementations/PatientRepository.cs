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
internal class PatientRepository : IPatientRepository
{
    private readonly IApplicationDbContext _dbContext;

    public PatientRepository(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Result> DeleteAsync(Patient patient, CancellationToken cancellationToken = default)
    {
        _dbContext.Patients.Remove(patient);
        return Task.FromResult(Result.Success());
    }

    public async Task<Result<List<Patient>>> GetByFilteredQueryAsync(CustomQuery<Patient> customQuery, Pagination pagination, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Patients
                                .AsNoTracking()
                                .EvaluateCustomQuery(customQuery)
                                .ApplyPagination(pagination)
                                .ToListAsync(cancellationToken);
    }

    public async Task<Result<Patient>> GetByIdAsync(Id patientId, CancellationToken cancellationToken = default)
    {
        var result = await _dbContext.Patients
                                        .Include(p => p.Appointments)
                                        .Where(p => p.Id == patientId)
                                        .FirstOrDefaultAsync(cancellationToken);

        if (result is null)
        {
            return Result<Patient>.Failure(RepositoryErrors.NotFoundError);
        }

        return result;
    }

    public async Task<Result> InsertNewAsync(Patient newPatient, CancellationToken cancellationToken = default)
    {
        await _dbContext.Patients.AddAsync(newPatient, cancellationToken);
        return Result.Success();
    }

    public async Task<Result<bool>> IsEmailExistsAsync(EmailAddress emailAddress, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Patients
                                .AsNoTracking()
                                .AnyAsync(p => p.EmailAddress == emailAddress, cancellationToken);
    }
}