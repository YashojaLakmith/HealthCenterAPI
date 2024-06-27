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
        var id = Id.CreateId(command.UserId);

        var invokerResult = await _invoker.GetInvokingUserAsync(cancellationToken);
        if (invokerResult.IsFailure)
        {
            return invokerResult;
        }

        var invokerId = Id.CreateId(invokerResult.Value.UserId);

        var adminResult = await _adminRepository.GetByIdAsync(id, cancellationToken);
        if(adminResult.IsFailure)
        {
            return adminResult;
        }

        var changeResult = await _changeRoleService.ChangeAdminRoleAsync(adminResult.Value, invokerId, command.NewRole, cancellationToken);
        if(changeResult.IsFailure)
        {
            return changeResult;
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
