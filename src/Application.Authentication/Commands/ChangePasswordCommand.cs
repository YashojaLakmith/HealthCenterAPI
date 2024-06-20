using Application.Authentication.Abstractions.CQRS;

namespace Application.Authentication.Commands;
public record ChangePasswordCommand(string EmailAddress, string CurrentPassword, string NewPassword) : ICommand;