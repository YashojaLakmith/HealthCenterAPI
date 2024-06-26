using Domain.Enum;

namespace Application.Admin.Views;
public sealed record AdminListItem(Guid UserId, string UserName, Role Role);
