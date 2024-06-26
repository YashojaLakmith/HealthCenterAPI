using Application.Abstractions.ReadOnlyRepositories;
using Application.CustomFilters;
using Application.Patient.Views;
using Domain.Common;
using Domain.Repositories;
using Domain.ValueObjects;
using Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;
using ReadOnlyRepositories.Evaluators;
using ReadOnlyRepositories.Extensions;

namespace ReadOnlyRepositories.Implementations;

internal sealed class ReadOnlyPatientRepository : IReadOnlyPatientRepository
{
    private readonly IApplicationDbContext _dbContext;

    public ReadOnlyPatientRepository(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<PatientDetailView>> GetPatientDetailViewAsync(Id patientId, CancellationToken cancellationToken = default)
    {
        var queryResult = await _dbContext.Patients
            .AsNoTracking()
            .Where(patient => patient.Id == patientId)
            .Select(patient => patient.AsDetailView())
            .FirstOrDefaultAsync(cancellationToken);

        return queryResult ?? Result<PatientDetailView>.Failure(RepositoryErrors.NotFoundError);
    }

    public async Task<Result<PatientDetailView>> GetPatientDetailViewAsync(NIC nic, CancellationToken cancellationToken = default)
    {
        var queryResult = await _dbContext.Patients
            .AsNoTracking()
            .Where(patient => patient.NIC == nic)
            .Select(patient => patient.AsDetailView())
            .FirstOrDefaultAsync(cancellationToken);

        return queryResult ?? Result<PatientDetailView>.Failure(RepositoryErrors.NotFoundError);
    }

    public async Task<Result<IReadOnlyCollection<PatientListItemView>>> GetPatientListAsync(PatientFilter filter, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Patients
            .AsNoTracking()
            .EvaluateFilter(filter)
            .Select(patient => patient.AsListItem())
            .ToListAsync(cancellationToken);
    }
}