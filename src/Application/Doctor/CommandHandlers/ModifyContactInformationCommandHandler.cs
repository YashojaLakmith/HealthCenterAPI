using Application.Abstractions.CQRS;
using Application.Doctor.Commands;

using Domain.Abstractions.DomainServices;
using Domain.Common;
using Domain.Common.Errors;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Doctor.CommandHandlers;
internal class ModifyContactInformationCommandHandler : ICommandHandler<ModifyContactInformationCommand>
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IEmailChangeService _emailChangeService;
    private readonly IPhoneNumberChangeService _phoneNumberChangeService;
    private readonly IUnitOfWork _unitOfWork;

    public ModifyContactInformationCommandHandler(
        IUnitOfWork unitOfWork,
        IDoctorRepository doctorRepository,
        IEmailChangeService emailChangeService,
        IPhoneNumberChangeService phoneNumberChangeService)
    {
        _unitOfWork = unitOfWork;
        _doctorRepository = doctorRepository;
        _emailChangeService = emailChangeService;
        _phoneNumberChangeService = phoneNumberChangeService;
    }

    public async Task<Result> HandleAsync(ModifyContactInformationCommand command, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var emailResult = command.EmailAddress is null ? null : EmailAddress.CreateEmailAddress(command.EmailAddress);
        var phoneNumberResult = command.PhoneNumber is null ? null : PhoneNumber.CreatePhoneNumber(command.PhoneNumber);
        var id = Id.CreateId(command.DoctorId);

        if(emailResult is null && phoneNumberResult is null)
        {
            return Result.Success();
        }

        if(emailResult is not null && emailResult.IsFailure)
        {
            return emailResult;
        }

        if(phoneNumberResult is not null && phoneNumberResult.IsFailure)
        {
            return phoneNumberResult;
        }

        var existingDoctor = await _doctorRepository.GetByIdAsync(id, cancellationToken);
        if (existingDoctor.IsFailure)
        {
            return Result.Failure(DoctorErrors.NotFound);
        }

        if(emailResult is not null)
        {
            var result = await _emailChangeService.ChangeDoctorEmailAsync(existingDoctor.Value, emailResult.Value, cancellationToken);
            if (result.IsFailure)
            {
                return result;
            }
        }

        if(phoneNumberResult is not null)
        {
            var result = await _phoneNumberChangeService.ChangeDoctorPhoneNumberAsync(existingDoctor.Value, phoneNumberResult.Value, cancellationToken);
            if (result.IsFailure)
            {
                return result;
            }
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
