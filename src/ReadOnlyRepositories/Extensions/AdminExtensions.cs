using Application.Admin.Views;
using Domain.Entities;

namespace ReadOnlyRepositories.Extensions;

internal static class AdminExtensions
{
    internal static UserDetailView AsDetailView(this Admin admin)
    {
        return new UserDetailView(
            admin.Id.Value,
            admin.AdminName.Value,
            admin.NIC.Value,
            admin.PhoneNumber.Value,
            admin.EmailAddress.Value,
            admin.Gender,
            admin.Role,
            admin.CreatedOn);
    }

    internal static UserListItem AsListItem(this Admin admin)
    {
        return new UserListItem(
            admin.Id.Value,
            admin.AdminName.Value,
            admin.Role);
    }
}