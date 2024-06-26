using Application.Authentication.Abstractions.CQRS;
using Application.Authentication.Commands;
using Authentication.ValueObjects;

namespace Application.Authentication.Abstractions.Factories;

public interface IAuthenticationCommandHandlerFactory
{
    ICommandHandler<ChangePasswordCommand> ChangePasswordCommandHandler { get; }
    ICommandHandler<SessionToken, LoginCommand> LoginCommandHandler { get; }
    ICommandHandler<LogoutCommand> LogoutCommandHandler { get; }
    ICommandHandler<ResetToken, ResetTokenRequestCommand> ResetTokenRequestCommandHandler { get; }
    ICommandHandler<ResetPasswordCommand> ResetPasswordCommandHandler { get; }
}