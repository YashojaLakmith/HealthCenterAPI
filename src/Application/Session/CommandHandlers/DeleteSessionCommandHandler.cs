using Application.Abstractions.CQRS;
using Application.Session.Commands;

using Domain.Common;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Session.CommandHandlers;
internal class DeleteSessionCommandHandler : ICommandHandler<DeleteSessionCommand>
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSessionCommandHandler(IDoctorRepository doctorRepository, IUnitOfWork unitOfWork)
    {
        _doctorRepository = doctorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> HandleAsync(DeleteSessionCommand command, CancellationToken cancellationToken = default)
    {
        var doctorId = Id.CreateId(command.DoctorId);
        var sessionId = Id.CreateId(command.SessionId);

        var doctorResult = await _doctorRepository.GetByIdAsync(doctorId, cancellationToken);
        if (doctorResult.IsFailure)
        {
            return doctorResult;
        }

        var result = doctorResult.Value.RemoveSession(sessionId);
        if (result.IsFailure)
        {
            return result;
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
