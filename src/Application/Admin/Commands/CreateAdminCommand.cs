using Application.Abstractions.CQRS;

using Domain.Enum;

namespace Application.Admin.Commands;
public sealed record CreateAdminCommand(string UserName, Role Role, string NIC, Gender Gender, string EmailAddress, string PhoneNumber) : ICommand;
