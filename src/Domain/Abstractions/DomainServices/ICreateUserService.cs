using Domain.Common;
using Domain.Enum;
using Domain.ValueObjects;

namespace Domain.Abstractions.DomainServices;
public interface ICreateUserService
{
    Task<Result> CreateAdminAsync(
        Name UserName,
        Role Role,
        NIC NIC,
        Gender Gender,
        EmailAddress EmailAddress,
        PhoneNumber PhoneNumber,
        Id invokerId,
        CancellationToken cancellationToken = default);
    Task<Result> CreateDoctorAsync(
        Name DoctorName,
        Description Description,
        Gender Gender,
        DoctorRegistrationNumber RegistrationNumber,
        EmailAddress EmailAddress,
        PhoneNumber PhoneNumber,
        CancellationToken cancellationToken = default);
    Task<Result> CreatePatientAsync(
        Name PatientName,
        DateOfBirth BirthDate,
        Gender Gender,
        NIC NIC,
        PhoneNumber PhoneNumber,
        EmailAddress EmailAddress,
        CancellationToken cancellationToken = default);
}