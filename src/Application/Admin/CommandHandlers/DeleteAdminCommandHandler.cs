
using Application.Abstractions.CQRS;
using Application.Abstractions.Invoker;
using Application.Common;

using Domain.Abstractions.DomainServices;
using Domain.Common;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Admin.CommandHandlers;
internal class DeleteAdminCommandHandler : ICommandHandler<IdCommand>
{
    private readonly IDeleteAdminService _deleteAdminService;
    private readonly ICommandQueryInvoker _invoker;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAdminCommandHandler(IDeleteAdminService deleteAdminService, ICommandQueryInvoker invoker, IUnitOfWork unitOfWork)
    {
        _deleteAdminService = deleteAdminService;
        _invoker = invoker;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> HandleAsync(IdCommand command, CancellationToken cancellationToken = default)
    {
        var id = Id.CreateId(command.Id);

        var invokerResult = await _invoker.GetInvokingUserAsync(cancellationToken);
        if (invokerResult.IsFailure)
        {
            return invokerResult;
        }

        var deleteResult = await _deleteAdminService.DeleteAdminAsync(
            id,
            Id.CreateId(invokerResult.Value.UserId),
            cancellationToken);

        if (deleteResult.IsFailure)
        {
            return deleteResult;
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
