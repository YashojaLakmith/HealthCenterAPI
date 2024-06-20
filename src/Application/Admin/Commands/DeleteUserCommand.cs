using Application.Abstractions.CQRS;

namespace Application.Admin.Commands;
public sealed record DeleteUserCommand(Guid UserId) : ICommand;
