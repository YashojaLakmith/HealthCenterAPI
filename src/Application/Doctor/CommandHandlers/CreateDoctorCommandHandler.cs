using Application.Abstractions.CQRS;
using Application.Doctor.Commands;

using Domain.Common;
using Domain.Common.Errors;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Doctor.CommandHandlers;
internal class CreateDoctorCommandHandler : ICommandHandler<CreateDoctorCommand>
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateDoctorCommandHandler(IDoctorRepository doctorRepository, IUnitOfWork unitOfWork)
    {
        _doctorRepository = doctorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> HandleAsync(CreateDoctorCommand command, CancellationToken cancellationToken = default)
    {
        var nameResult = Name.Create(command.DoctorName);
        if (nameResult.IsFailure)
        {
            return nameResult;
        }

        var emailResult = EmailAddress.CreateEmailAddress(command.EmailAddress);
        if (emailResult.IsFailure)
        {
            return emailResult;
        }

        var phoneNumberResult = PhoneNumber.CreatePhoneNumber(command.PhoneNumber);
        if (phoneNumberResult.IsFailure)
        {
            return phoneNumberResult;
        }

        var regNumberResult = DoctorRegistrationNumber.Create(command.RegistrationNumber);
        if (regNumberResult.IsFailure)
        {
            return regNumberResult;
        }

        var descriptionResult = Description.CreateDescription(command.Description);
        if (descriptionResult.IsFailure)
        {
            return descriptionResult;
        }

        var emailExistence = await _doctorRepository.IsEmailExistsAsync(emailResult.Value, cancellationToken);
        if (emailExistence.Value)
        {
            return Result.Failure(EmailErrors.EmailAlreadyExists);
        }

        var registrationNumberExistence = await _doctorRepository.IsRegistrationNumberExistsAsync(regNumberResult.Value, cancellationToken);
        if (registrationNumberExistence.Value)
        {
            return Result.Failure(RegistrationNumberErrors.RegistrationNumberAlreadyExists);
        }

        var newDoctorResult = Domain.Entities.Doctor.Create(nameResult.Value, descriptionResult.Value, regNumberResult.Value, command.Gender);

        await _doctorRepository.CreateNewAsync(newDoctorResult.Value, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
