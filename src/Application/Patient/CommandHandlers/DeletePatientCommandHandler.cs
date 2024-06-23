using Application.Abstractions.CQRS;
using Application.Common;

using Domain.Common;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Patient.CommandHandlers;
internal class DeletePatientCommandHandler : ICommandHandler<IdCommand>
{
    private readonly IPatientRepository _patientRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePatientCommandHandler(IPatientRepository patientRepository, IUnitOfWork unitOfWork)
    {
        _patientRepository = patientRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> HandleAsync(IdCommand command, CancellationToken cancellationToken = default)
    {
        var idResult = Id.CreateId(command.Id);
        if (idResult.IsFailure)
        {
            return idResult;
        }

        var patientResult = await _patientRepository.GetByIdAsync(idResult.Value, cancellationToken);
        if (patientResult.IsFailure)
        {
            return patientResult;
        }

        await _patientRepository.DeleteAsync(patientResult.Value, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
