using Domain.Abstractions.DomainServices;
using Domain.Common;
using Domain.Common.Errors;
using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Domain.Services;
internal sealed class EmailChangeService : IEmailChangeService
{
    private readonly IAdminRepository _adminRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IPatientRepository _patientRepository;

    public EmailChangeService(IPatientRepository patientRepository, IDoctorRepository doctorRepository, IAdminRepository adminRepository)
    {
        _patientRepository = patientRepository;
        _doctorRepository = doctorRepository;
        _adminRepository = adminRepository;
    }

    public async Task<Result> ChangePatientEmailAsync(Patient patient, EmailAddress emailAddress, CancellationToken cancellationToken = default)
    {
        var isEmailInUse = await _patientRepository.IsEmailExistsAsync(emailAddress, cancellationToken);
        if (isEmailInUse)
        {
            return Result.Failure(ChangeEmailErrors.EmailAlreadyExists);
        }

        return patient.ChangeEmail(emailAddress);
    }

    public async Task<Result> ChangeDoctorEmailAsync(Doctor doctor, EmailAddress emailAddress, CancellationToken cancellationToken = default)
    {
        var isEmailInUse = await _doctorRepository.IsEmailExistsAsync(emailAddress, cancellationToken);
        if (isEmailInUse)
        {
            return Result.Failure(ChangeEmailErrors.EmailAlreadyExists);
        }

        return doctor.ChangeEmail(emailAddress);
    }

    public async Task<Result> ChangeAdminEmailAsync(Admin admin, Id invokingAdminId, EmailAddress emailAddress, CancellationToken cancellationToken = default)
    {
        if(invokingAdminId != admin.Id)
        {
            return Result.Failure(ChangeEmailErrors.Unauthorized);
        }

        var isEmailInUse = await _adminRepository.IsEmailExistsAsync(emailAddress, cancellationToken);
        if (isEmailInUse)
        {
            return Result.Failure(ChangeEmailErrors.EmailAlreadyExists);
        }

        return admin.ChangeEmailAddress(emailAddress);
    }
}
