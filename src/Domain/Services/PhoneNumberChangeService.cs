using Domain.Abstractions.DomainServices;
using Domain.Common;
using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Services;
public class PhoneNumberChangeService : IPhoneNumberChangeService
{
    public Task<Result> ChangePatientPhoneNumberAsync(Patient patient, PhoneNumber newPhoneNumber, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Result> ChangeDoctorPhoneNumberAsync(Doctor doctor, PhoneNumber newPhoneNumber, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Result> ChangeAdminPhoneNumberAsync(Admin admin, PhoneNumber newPhoneNumber, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
