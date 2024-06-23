using Domain.Common;
using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Abstractions.DomainServices;
public interface IPhoneNumberChangeService
{
    Task<Result> ChangeAdminPhoneNumberAsync(Admin admin, PhoneNumber newPhoneNumber, CancellationToken cancellationToken = default);
    Task<Result> ChangeDoctorPhoneNumberAsync(Doctor doctor, PhoneNumber newPhoneNumber, CancellationToken cancellationToken = default);
    Task<Result> ChangePatientPhoneNumberAsync(Patient patient, PhoneNumber newPhoneNumber, CancellationToken cancellationToken = default);
}