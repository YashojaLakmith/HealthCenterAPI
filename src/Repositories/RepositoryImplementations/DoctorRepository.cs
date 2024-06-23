using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;

using Infrastructure.Abstractions;

using Microsoft.EntityFrameworkCore;

namespace Repositories.RepositoryImplementations;
internal class DoctorRepository : IDoctorRepository
{
    private readonly IApplicationDbContext _dbContext;

    public DoctorRepository(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result> CreateNewAsync(Doctor newDoctor, CancellationToken cancellationToken = default)
    {
        await _dbContext.Doctors.AddAsync(newDoctor, cancellationToken);
        return Result.Success();
    }

    public async Task<bool> IsPhoneNumberExistsAsync(PhoneNumber newPhoneNumber, CancellationToken cancellationToken)
    {
        return await _dbContext.Doctors
            .AsNoTracking()
            .AnyAsync(doctor => doctor.PhoneNumber == newPhoneNumber, cancellationToken);
    }

    async Task<bool> IDoctorRepository.IsEmailExistsAsync(EmailAddress emailAddress, CancellationToken cancellationToken)
    {
        return await _dbContext.Doctors
            .AsNoTracking()
            .AnyAsync(doctor => doctor.DoctorEmailAddress == emailAddress, cancellationToken);
    }

    public Task<Result> DeleteAsync(Doctor doctor, CancellationToken cancellationToken = default)
    {
        _dbContext.Doctors.Remove(doctor);
        return Task.FromResult(Result.Success());
    }

    public async Task<Result<Doctor>> GetByIdAsync(Id doctorId, CancellationToken cancellationToken = default)
    {
        var result = await _dbContext.Doctors
                                    .Include(doc => doc.Sessions)
                                    .Where(doc => doc.Id == doctorId)
                                    .FirstOrDefaultAsync(cancellationToken);

        return result ?? Result<Doctor>.Failure(RepositoryErrors.NotFoundError);
    }

    public async Task<Result<bool>> IsRegistrationNumberExistsAsync(DoctorRegistrationNumber registrationNumber, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Doctors
                                .AsNoTracking()
                                .AnyAsync(doc => doc.RegistrationNumber == registrationNumber, cancellationToken);
    }
}
