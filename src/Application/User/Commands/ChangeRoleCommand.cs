using Application.Abstractions.CQRS;

using Domain.Enum;

namespace Application.User.Commands;
public sealed record ChangeRoleCommand(Guid UserId, Role NewRole) : ICommand;
