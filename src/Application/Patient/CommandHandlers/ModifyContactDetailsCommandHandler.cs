using Application.Abstractions.CQRS;
using Application.Patient.Commands;

using Domain.Abstractions.DomainServices;
using Domain.Common;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Patient.CommandHandlers;
internal class ModifyContactDetailsCommandHandler : ICommandHandler<ModifyContactInformationCommand>
{
    private readonly IPatientRepository _patientRepository;
    private readonly IEmailChangeService _emailChangeService;
    private readonly IPhoneNumberChangeService _phoneNumberChangeService;
    private readonly IUnitOfWork _unitOfWork;

    public ModifyContactDetailsCommandHandler(
        IPhoneNumberChangeService phoneNumberChangeService,
        IEmailChangeService emailChangeService,
        IPatientRepository patientRepository,
        IUnitOfWork unitOfWork)
    {
        _phoneNumberChangeService = phoneNumberChangeService;
        _emailChangeService = emailChangeService;
        _patientRepository = patientRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> HandleAsync(ModifyContactInformationCommand command, CancellationToken cancellationToken = default)
    {
        var idResult = Id.CreateId(command.PatientId);
        if (idResult.IsFailure)
        {
            return idResult;
        }

        var emailResult = command.EmailAddress is null ? null : EmailAddress.CreateEmailAddress(command.EmailAddress);
        if (emailResult is not null && emailResult.IsFailure)
        {
            return emailResult;
        }

        var phoneNumberResult = command.PhoneNumber is null ? null : PhoneNumber.CreatePhoneNumber(command.PhoneNumber);
        if (phoneNumberResult is not null && phoneNumberResult.IsFailure)
        {
            return phoneNumberResult;
        }

        var patientResult = await _patientRepository.GetByIdAsync(idResult.Value, cancellationToken);
        if (patientResult.IsFailure)
        {
            return patientResult;
        }

        if(emailResult is not null)
        {
            var result = await _emailChangeService.ChangePatientEmailAsync(patientResult.Value, emailResult.Value, cancellationToken);
            if (result.IsFailure)
            {
                return result;
            }
        }

        if(phoneNumberResult is not null)
        {
            var result = await _phoneNumberChangeService.ChangePatientPhoneNumberAsync(patientResult.Value, phoneNumberResult.Value, cancellationToken);
            if (result.IsFailure)
            {
                return result;
            }
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
