using Domain.Enum;

namespace Application.Admin.Views;
public sealed record AdminDetailView(Guid UserId, string UserName, string NIC, string PhoneNumber, string EmailAddress, Gender Gender, Role Role, DateTime CreatedOn);
