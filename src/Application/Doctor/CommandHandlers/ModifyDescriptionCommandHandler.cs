using Application.Abstractions.CQRS;
using Application.Doctor.Commands;

using Domain.Common;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Doctor.CommandHandlers;
internal class ModifyDescriptionCommandHandler : ICommandHandler<ModifyDescriptionCommand>
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ModifyDescriptionCommandHandler(IUnitOfWork unitOfWork, IDoctorRepository doctorRepository)
    {
        _unitOfWork = unitOfWork;
        _doctorRepository = doctorRepository;
    }

    public async Task<Result> HandleAsync(ModifyDescriptionCommand command, CancellationToken cancellationToken = default)
    {
        var doctorIdResult = Id.CreateId(command.DoctorId);
        if (doctorIdResult.IsFailure)
        {
            return doctorIdResult;
        }

        var descriptionResult = Description.CreateDescription(command.NewDescription);
        if (descriptionResult.IsFailure)
        {
            return descriptionResult;
        }

        var doctorResult = await _doctorRepository.GetByIdAsync(doctorIdResult.Value, cancellationToken);
        if (doctorResult.IsFailure)
        {
            return doctorResult;
        }

        doctorResult.Value.ChangeDescription(descriptionResult.Value);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
