using Application.Abstractions.CQRS;
using Application.Session.Commands;

using Domain.Common;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Session.CommandHandlers;
internal class CreateSessionCommandHandler : ICommandHandler<CreateSessionCommand>
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateSessionCommandHandler(IUnitOfWork unitOfWork, IDoctorRepository doctorRepository)
    {
        _unitOfWork = unitOfWork;
        _doctorRepository = doctorRepository;
    }

    public async Task<Result> HandleAsync(CreateSessionCommand command, CancellationToken cancellationToken = default)
    {
        var id = Id.CreateId(command.DoctorId);

        var sessionSpanResult = SessionSpan.Create(command.SessionStart, command.SessionEnd);
        if (sessionSpanResult.IsFailure)
        {
            return sessionSpanResult;
        }

        var doctorResult = await _doctorRepository.GetByIdAsync(id, cancellationToken);
        if (doctorResult.IsFailure)
        {
            return doctorResult;
        }

        var result = doctorResult.Value.AddSession(sessionSpanResult.Value);
        if (result.IsFailure)
        {
            return result;
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
