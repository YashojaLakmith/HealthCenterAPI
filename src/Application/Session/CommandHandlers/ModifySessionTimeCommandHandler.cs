using Application.Abstractions.CQRS;
using Application.Session.Commands;

using Domain.Common;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Session.CommandHandlers;
internal class ModifySessionTimeCommandHandler : ICommandHandler<ModifySessionTimeCommand>
{
    private readonly ISessionRepository _sessionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ModifySessionTimeCommandHandler(IUnitOfWork unitOfWork, ISessionRepository sessionRepository)
    {
        _unitOfWork = unitOfWork;
        _sessionRepository = sessionRepository;
    }

    public async Task<Result> HandleAsync(ModifySessionTimeCommand command, CancellationToken cancellationToken = default)
    {
        var idResult = Id.CreateId(command.SessionId);
        if (idResult.IsFailure)
        {
            return idResult;
        }

        var spanResult = SessionSpan.Create(command.SessionStartTime, command.SessionEndTime);
        if (spanResult.IsFailure)
        {
            return spanResult;
        }

        var sessionResult = await _sessionRepository.GetByIdAsync(idResult.Value, cancellationToken);
        if (sessionResult.IsFailure)
        {
            return sessionResult;
        }

        var changeResult = sessionResult.Value.ModifySessionTime(spanResult.Value);
        if (changeResult.IsFailure)
        {
            return changeResult;
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
