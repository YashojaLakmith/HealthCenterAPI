using Domain.Enum;

namespace Application.User.Views;
public sealed record UserDetailView(Guid UserId, string UserName, string NIC, string PhoneNumber, string EmailAddress, Gender Gender, Role Role, DateTime CreatedOn);
