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
        var docIdResult = Id.CreateId(command.DoctorId);
        if (docIdResult.IsFailure)
        {
            return docIdResult;
        }

        var sessionIdResult = Id.CreateId(command.SessionId);
        if (sessionIdResult.IsFailure)
        {
            return sessionIdResult;
        }

        var doctorResult = await _doctorRepository.GetByIdAsync(docIdResult.Value, cancellationToken);
        if (doctorResult.IsFailure)
        {
            return doctorResult;
        }

        var result = doctorResult.Value.RemoveSession(sessionIdResult.Value);
        if (result.IsFailure)
        {
            return result;
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
