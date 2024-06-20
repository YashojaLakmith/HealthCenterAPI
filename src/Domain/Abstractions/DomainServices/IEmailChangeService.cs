using Domain.Common;
using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Abstractions.DomainServices;
public interface IEmailChangeService
{
    Task<Result> ChangeAdminEmailAsync(Admin admin, EmailAddress emailAddress, CancellationToken cancellationToken = default);
    Task<Result> ChangeDoctorEmailAsync(Doctor doctor, EmailAddress emailAddress, CancellationToken cancellationToken = default);
    Task<Result> ChangePatientEmailAsync(Patient patient, EmailAddress emailAddress, CancellationToken cancellationToken = default);
}