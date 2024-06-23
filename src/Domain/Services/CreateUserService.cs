using Domain.Abstractions.DomainServices;
using Domain.Common;
using Domain.Enum;
using Domain.ValueObjects;

namespace Domain.Services;
internal sealed class CreateUserService : ICreateUserService
{
    public Task<Result> CreatePatientAsync(Name PatientName,
        DateOfBirth BirthDate,
        Gender Gender,
        NIC NIC,
        PhoneNumber PhoneNumber,
        EmailAddress EmailAddress,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Result> CreateDoctorAsync(
        Name DoctorName,
        Description Description,
        Gender Gender,
        DoctorRegistrationNumber RegistrationNumber,
        EmailAddress EmailAddress,
        PhoneNumber PhoneNumber, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Result> CreateAdminAsync(
        Name UserName,
        Role Role,
        NIC NIC,
        Gender Gender,
        EmailAddress EmailAddress,
        PhoneNumber PhoneNumber, Id invokerId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
