using Application.CustomFilters;
using Application.Doctor.Views;
using Domain.Common;
using Domain.ValueObjects;

namespace Application.Abstractions.ReadOnlyRepositories;

public interface IReadOnlyDoctorRepository
{
    Task<Result<DoctorDetailViewInternal>> GetDoctorDetailsForInternalAsync(
        Id doctorId,
        CancellationToken cancellationToken = default);

    Task<Result<DoctorDetailViewPublic>> GetDoctorDetailsForPublicAsync(
        Id doctorId,
        CancellationToken cancellationToken = default);
    
    Task<Result<DoctorDetailViewInternal>> GetDoctorDetailsForInternalAsync(
        DoctorRegistrationNumber registrationNumber,
        CancellationToken cancellationToken = default);

    Task<Result<DoctorDetailViewPublic>> GetDoctorDetailsForPublicAsync(
        DoctorRegistrationNumber registrationNumber,
        CancellationToken cancellationToken = default);

    Task<Result<IReadOnlyCollection<DoctorListItem>>> GetDoctorListAsync(
        DoctorFilter filter,
        CancellationToken cancellationToken = default);
}