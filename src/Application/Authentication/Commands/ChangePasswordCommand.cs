using Application.Abstractions.CQRS;

namespace Application.Authentication.Commands;
public record ChangePasswordCommand(Guid UserId, string CurrentPassword, string NewPassword) : ICommand;