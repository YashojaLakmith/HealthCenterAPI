using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;

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

    public async Task<bool> IsPhoneNumberExistsAsync(PhoneNumber newPhoneNumber, CancellationToken cancellationToken)
    {
        return await _dbContext.Patients
            .AsNoTracking()
            .AnyAsync(patient => patient.PhoneNumber == newPhoneNumber, cancellationToken);
    }

    public async Task<Result<Patient>> GetByIdAsync(Id patientId, CancellationToken cancellationToken = default)
    {
        var result = await _dbContext.Patients
                                        .Include(p => p.Appointments)
                                        .Where(p => p.Id == patientId)
                                        .FirstOrDefaultAsync(cancellationToken);

        return result ?? Result<Patient>.Failure(RepositoryErrors.NotFoundError);
    }

    public async Task<Result> InsertNewAsync(Patient newPatient, CancellationToken cancellationToken = default)
    {
        await _dbContext.Patients.AddAsync(newPatient, cancellationToken);
        return Result.Success();
    }

    public async Task<bool> IsEmailExistsAsync(EmailAddress emailAddress, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Patients
                                .AsNoTracking()
                                .AnyAsync(p => p.EmailAddress == emailAddress, cancellationToken);
    }
}