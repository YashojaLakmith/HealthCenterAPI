using Application.Abstractions.CQRS;
using Application.Abstractions.Invoker;
using Application.Admin.Commands;

using Domain.Abstractions.DomainServices;
using Domain.Common;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Admin.CommandHandlers;
internal class ChangeRoleCommandHandler : ICommandHandler<ChangeRoleCommand>
{
    private readonly IAdminRepository _adminRepository;
    private readonly IChangeAdminRoleService _changeRoleService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICommandQueryInvoker _invoker;

    public ChangeRoleCommandHandler(IUnitOfWork unitOfWork, IChangeAdminRoleService changeRoleService, IAdminRepository adminRepository, ICommandQueryInvoker invoker)
    {
        _unitOfWork = unitOfWork;
        _changeRoleService = changeRoleService;
        _adminRepository = adminRepository;
        _invoker = invoker;
    }

    public async Task<Result> HandleAsync(ChangeRoleCommand command, CancellationToken cancellationToken = default)
    {
        var idResult = Id.CreateId(command.UserId);
        if (idResult.IsFailure)
        {
            return idResult;
        }

        var invokerResult = await _invoker.GetInvokingUserAsync(cancellationToken);
        if (invokerResult.IsFailure)
        {
            return invokerResult;
        }

        var invokerIdResult = Id.CreateId(invokerResult.Value.UserId);
        if (invokerIdResult.IsFailure)
        {
            return invokerIdResult;
        }

        var adminResult = await _adminRepository.GetByIdAsync(idResult.Value, cancellationToken);
        if(adminResult.IsFailure)
        {
            return adminResult;
        }

        var changeResult = await _changeRoleService.ChangeAdminRoleAsync(adminResult.Value, invokerIdResult.Value, command.NewRole, cancellationToken);
        if(changeResult.IsFailure)
        {
            return changeResult;
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
