using Application.Abstractions.CQRS;

namespace Application.User.Commands;
public sealed record DeleteUserCommand(Guid UserId) : ICommand;
