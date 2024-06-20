using Domain.Common;
using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Repositories;
public interface IPatientRepository
{
    Task<Result<Patient>> GetByIdAsync(Id patientId, CancellationToken cancellationToken = default);

    Task<bool> IsEmailExistsAsync(EmailAddress registrationNumber, CancellationToken cancellationToken = default);

    Task<Result> InsertNewAsync(Patient newPatient, CancellationToken cancellationToken = default);

    Task<Result> DeleteAsync(Patient patient, CancellationToken cancellationToken = default);

    Task<bool> IsPhoneNumberExistsAsync(PhoneNumber newPhoneNumber, CancellationToken cancellationToken);
}
