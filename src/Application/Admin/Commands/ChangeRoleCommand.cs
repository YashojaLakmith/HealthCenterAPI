using Application.Abstractions.CQRS;

using Domain.Enum;

namespace Application.Admin.Commands;
public sealed record ChangeRoleCommand(Guid UserId, Role NewRole) : ICommand;
