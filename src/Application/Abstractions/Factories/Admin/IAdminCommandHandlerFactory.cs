using Application.Abstractions.CQRS;
using Application.Admin.Commands;
using Application.Common;

namespace Application.Abstractions.Factories.Admin;

public interface IAdminCommandHandlerFactory
{
    ICommandHandler<ChangeRoleCommand> ChangeRoleCommandHandler { get; }
    ICommandHandler<CreateUserCommand> CreateAdminCommandHandler { get; }
    ICommandHandler<IdCommand> DeleteAdminCommandHandler { get; }
    ICommandHandler<ModifyContactInformationCommand> ModifyContactInformationCommandHandler { get; }
}