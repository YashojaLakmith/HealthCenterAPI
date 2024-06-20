using Application.Abstractions.CQRS;

namespace Application.Admin.Commands;
public sealed record ModifyContactInformationCommand(Guid UserId, string? NewEmail, string? NewPhoneNumber) : ICommand;
