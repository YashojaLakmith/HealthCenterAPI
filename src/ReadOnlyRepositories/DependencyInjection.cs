using Application.Abstractions.ReadOnlyRepositories;
using Microsoft.Extensions.DependencyInjection;
using ReadOnlyRepositories.Implementations;

namespace ReadOnlyRepositories;

public static class DependencyInjection
{
    public static IServiceCollection AddReadOnlyRepositories(this IServiceCollection services)
    {
        return services
            .AddScoped<IReadOnlyAdminRepository, ReadOnlyAdminRepository>()
            .AddScoped<IReadOnlyAppointmentRepository, ReadOnlyAppointmentRepository>()
            .AddScoped<IReadOnlyDoctorRepository, ReadOnlyDoctorRepository>()
            .AddScoped<IReadOnlyPatientRepository, ReadOnlyPatientRepository>()
            .AddScoped<IReadOnlySessionRepository, ReadOnlySessionRepository>();
    }
}