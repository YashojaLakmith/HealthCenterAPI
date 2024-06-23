using Domain.Abstractions.DomainServices;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        return services
            .AddScoped<IChangeAdminRoleService, ChangeAdminRoleService>()
            .AddScoped<ICreateUserService, CreateUserService>()
            .AddScoped<IDeleteAdminService, DeleteAdminService>()
            .AddScoped<IEmailChangeService, EmailChangeService>()
            .AddScoped<IPhoneNumberChangeService, PhoneNumberChangeService>();
    }
}