using Application.Abstractions.CQRS;
using Application.Common;

using Domain.Common;
using Domain.Common.Errors;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Doctor.CommandHandlers;
internal class DeleteDoctorCommandHandler : ICommandHandler<IdCommand>
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDoctorCommandHandler(IDoctorRepository doctorRepository, IUnitOfWork unitOfWork)
    {
        _doctorRepository = doctorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> HandleAsync(IdCommand command, CancellationToken cancellationToken = default)
    {
        var idResult = Id.CreateId(command.Id);
        var existsResult = await _doctorRepository.GetByIdAsync(idResult.Value, cancellationToken);

        if (existsResult.IsFailure)
        {
            return existsResult;
        }

        await _doctorRepository.DeleteAsync(existsResult.Value, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
