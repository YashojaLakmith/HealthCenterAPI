using Domain.Abstractions.DomainServices;
using Domain.Common;
using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Services;
public sealed class EmailChangeService : IEmailChangeService
{
    public Task<Result> ChangePatientEmailAsync(Patient patient, EmailAddress emailAddress, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Result> ChangeDoctorEmailAsync(Doctor doctor, EmailAddress emailAddress, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Result> ChangeAdminEmailAsync(Admin admin, EmailAddress emailAddress, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
