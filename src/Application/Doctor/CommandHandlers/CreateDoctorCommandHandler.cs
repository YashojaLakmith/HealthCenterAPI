using Application.Abstractions.CQRS;
using Application.Doctor.Commands;

using Domain.Abstractions.DomainServices;
using Domain.Common;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Doctor.CommandHandlers;
internal class CreateDoctorCommandHandler : ICommandHandler<CreateDoctorCommand>
{
    private readonly ICreateUserService _createUserService;
    private readonly IUnitOfWork _unitOfWork;

    public CreateDoctorCommandHandler(ICreateUserService createUserService, IUnitOfWork unitOfWork)
    {
        _createUserService = createUserService;
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

        var result = await _createUserService.CreateDoctorAsync(
            nameResult.Value,
            descriptionResult.Value,
            command.Gender,
            regNumberResult.Value,
            emailResult.Value,
            phoneNumberResult.Value,
            cancellationToken
            );

        if (result.IsFailure)
        {
            return result;
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
