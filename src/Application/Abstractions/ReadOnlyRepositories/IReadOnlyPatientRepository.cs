using Application.CustomFilters;
using Application.Patient.Views;
using Domain.Common;
using Domain.ValueObjects;

namespace Application.Abstractions.ReadOnlyRepositories;

public interface IReadOnlyPatientRepository
{
    Task<Result<PatientDetailView>> GetPatientDetailViewAsync(
        Id patientId,
        CancellationToken cancellationToken = default);
    
    Task<Result<PatientDetailView>> GetPatientDetailViewAsync(
        NIC nic,
        CancellationToken cancellationToken = default);

    Task<Result<IReadOnlyCollection<PatientListItemView>>> GetPatientListAsync(
        PatientFilter filter,
        CancellationToken cancellationToken = default);
}