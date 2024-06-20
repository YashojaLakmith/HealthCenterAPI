using Domain.Abstractions.DomainServices;
using Domain.Common;
using Domain.Common.Errors;
using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Domain.Services;
public class PhoneNumberChangeService : IPhoneNumberChangeService
{
    private readonly IPatientRepository _patientRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IAdminRepository _adminRepository;

    public PhoneNumberChangeService(IAdminRepository adminRepository, IDoctorRepository doctorRepository, IPatientRepository patientRepository)
    {
        _adminRepository = adminRepository;
        _doctorRepository = doctorRepository;
        _patientRepository = patientRepository;
    }

    public async Task<Result> ChangePatientPhoneNumberAsync(Patient patient, PhoneNumber newPhoneNumber, CancellationToken cancellationToken = default)
    {
        var isPhoneNumberExists = await _patientRepository.IsPhoneNumberExistsAsync(newPhoneNumber, cancellationToken);
        if (isPhoneNumberExists)
        {
            return Result.Failure(ChangePhoneNumberErrors.PhoneNumberAlreadyInUse);
        }

        return patient.ChangePhoneNumber(newPhoneNumber);
    }

    public async Task<Result> ChangeDoctorPhoneNumberAsync(Doctor doctor, PhoneNumber newPhoneNumber, CancellationToken cancellationToken = default)
    {
        var isPhoneNumberExists = await _doctorRepository.IsPhoneNumberExistsAsync(newPhoneNumber, cancellationToken);
        if (isPhoneNumberExists)
        {
            return Result.Failure(ChangePhoneNumberErrors.PhoneNumberAlreadyInUse);
        }

        return doctor.ChangePhoneNumber(newPhoneNumber);
    }

    public async Task<Result> ChangeAdminPhoneNumberAsync(Admin admin, PhoneNumber newPhoneNumber, CancellationToken cancellationToken = default)
    {
        var isPhoneNumberExists = await _adminRepository.IsPhoneNumberExistsAsync(newPhoneNumber, cancellationToken);
        if (isPhoneNumberExists)
        {
            return Result.Failure(ChangePhoneNumberErrors.PhoneNumberAlreadyInUse);
        }
        
        return admin.ChangePhoneNumber(newPhoneNumber);
    }
}
