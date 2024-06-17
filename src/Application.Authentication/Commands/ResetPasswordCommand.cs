using Application.Authentication.Abstractions.CQRS;

namespace Application.Authentication.Commands;
public sealed record ResetPasswordCommand(string ResetToken, string NewPassword) : ICommand;