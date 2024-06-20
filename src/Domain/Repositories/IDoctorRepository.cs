﻿using Domain.Common;
using Domain.Entities;
using Domain.Query;
using Domain.ValueObjects;

namespace Domain.Repositories;
public interface IDoctorRepository
{
    Task<Result<bool>> IsDoctorExistsAsync(Id doctorId, CancellationToken cancellationToken = default);

    Task<Result<Doctor>> GetByIdAsync(Id doctorId, CancellationToken cancellationToken = default);

    Task<Result<Doctor>> GetByRegistrationNumberAsync(DoctorRegistrationNumber registrationNumber, CancellationToken cancellationToken = default);

    Task<Result<bool>> IsRegistrationNumberExistsAsync(DoctorRegistrationNumber registrationNumber, CancellationToken cancellationToken = default);

    Task<bool> IsEmailExistsAsync(EmailAddress registrationNumber, CancellationToken cancellationToken = default);

    Task<Result> DeleteAsync(Doctor doctor, CancellationToken cancellationToken = default);

    Task<Result> CreateNewAsync(Doctor newDoctor, CancellationToken cancellationToken = default);

    Task<bool> IsPhoneNumberExistsAsync(PhoneNumber newPhoneNumber, CancellationToken cancellationToken);
}
