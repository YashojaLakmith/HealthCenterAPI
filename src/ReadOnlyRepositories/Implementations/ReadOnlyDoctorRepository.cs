using Application.Abstractions.ReadOnlyRepositories;
using Application.CustomFilters;
using Application.Doctor.Views;
using Domain.Common;
using Domain.Repositories;
using Domain.ValueObjects;
using Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;
using ReadOnlyRepositories.Evaluators;
using ReadOnlyRepositories.Extensions;

namespace ReadOnlyRepositories.Implementations;

internal sealed class ReadOnlyDoctorRepository : IReadOnlyDoctorRepository
{
    private readonly IApplicationDbContext _dbContext;

    public ReadOnlyDoctorRepository(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<DoctorDetailViewInternal>> GetDoctorDetailsForInternalAsync(
        Id doctorId,
        CancellationToken cancellationToken = default)
    {
        var queryResult = await _dbContext.Doctors
            .AsNoTracking()
            .Where(doctor => doctor.Id == doctorId)
            .Select(doctor => doctor.AsDetailViewInternal())
            .FirstOrDefaultAsync(cancellationToken);

        return queryResult ?? Result<DoctorDetailViewInternal>.Failure(RepositoryErrors.NotFoundError);
    }

    public async Task<Result<DoctorDetailViewPublic>> GetDoctorDetailsForPublicAsync(
        Id doctorId,
        CancellationToken cancellationToken = default)
    {
        var queryResult = await _dbContext.Doctors
            .AsNoTracking()
            .Where(doctor => doctor.Id == doctorId)
            .Select(doctor => doctor.AsDetailViewPublic())
            .FirstOrDefaultAsync(cancellationToken);

        return queryResult ?? Result<DoctorDetailViewPublic>.Failure(RepositoryErrors.NotFoundError);
    }

    public async Task<Result<DoctorDetailViewInternal>> GetDoctorDetailsForInternalAsync(
        DoctorRegistrationNumber registrationNumber,
        CancellationToken cancellationToken = default)
    {
        var queryResult = await _dbContext.Doctors
            .AsNoTracking()
            .Where(doctor => doctor.RegistrationNumber == registrationNumber)
            .Select(doctor => doctor.AsDetailViewInternal())
            .FirstOrDefaultAsync(cancellationToken);

        return queryResult ?? Result<DoctorDetailViewInternal>.Failure(RepositoryErrors.NotFoundError);
    }

    public async Task<Result<DoctorDetailViewPublic>> GetDoctorDetailsForPublicAsync(
        DoctorRegistrationNumber registrationNumber,
        CancellationToken cancellationToken = default)
    {
        var queryResult = await _dbContext.Doctors
            .AsNoTracking()
            .Where(doctor => doctor.RegistrationNumber == registrationNumber)
            .Select(doctor => doctor.AsDetailViewPublic())
            .FirstOrDefaultAsync(cancellationToken);

        return queryResult ?? Result<DoctorDetailViewPublic>.Failure(RepositoryErrors.NotFoundError);
    }

    public async Task<Result<IReadOnlyCollection<DoctorListItem>>> GetDoctorListAsync(
        DoctorFilter filter,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Doctors
            .AsNoTracking()
            .EvaluateFiter(filter)
            .Select(doctor => doctor.AsListItem())
            .ToListAsync(cancellationToken);
    }
}