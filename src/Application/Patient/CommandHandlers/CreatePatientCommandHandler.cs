using Application.Abstractions.CQRS;
using Application.Patient.Commands;
using Domain.Abstractions.DomainServices;
using Domain.Common;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Patient.CommandHandlers;
internal class CreatePatientCommandHandler : ICommandHandler<CreatePatientCommand>
{
    private readonly ICreateUserService _createUserService;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePatientCommandHandler(ICreateUserService createUserService, IUnitOfWork unitOfWork)
    {
        _createUserService = createUserService;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> HandleAsync(CreatePatientCommand command, CancellationToken cancellationToken = default)
    {
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

        var nameResult = Name.Create(command.PatientName);
        if (nameResult.IsFailure)
        {
            return nameResult;
        }

        var nicResult = NIC.Create(command.NIC);
        if (nicResult.IsFailure)
        {
            return nicResult;
        }

        var dobResult = DateOfBirth.Create(command.BirthDate);
        if (dobResult.IsFailure)
        {
            return dobResult;
        }

        var creationResult = await _createUserService.CreatePatientAsync(
            nameResult.Value,
            dobResult.Value,
            command.Gender,
            nicResult.Value,
            phoneNumberResult.Value,
            emailResult.Value,
            cancellationToken);

        if (creationResult.IsFailure)
        {
            return creationResult;
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
