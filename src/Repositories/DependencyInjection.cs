using Authentication.Repositories;

using Domain.Repositories;

using Microsoft.Extensions.DependencyInjection;

using Repositories.RepositoryImplementations;

namespace Repositories;
public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services.AddScoped<IAppointmentRepository, AppointmentRepository>()
                        .AddScoped<ICredentialRepository, CredentialRepository>()
                        .AddScoped<IDoctorRepository, DoctorRepository>()
                        .AddScoped<IPatientRepository, PatientRepository>()
                        .AddScoped<ISessionRepository, SessionRepository>()
                        .AddScoped<IAdminRepository, AdminRepository>();
    }
}
