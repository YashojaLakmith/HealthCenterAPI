using Application.Abstractions.Factories.Admin;
using Application.Abstractions.Factories.Appointment;
using Application.Abstractions.Factories.Doctor;
using Application.Abstractions.Factories.Patient;
using Application.Abstractions.Factories.Session;
using Application.Factories.Admin;
using Application.Factories.Appointment;
using Application.Factories.Doctor;
using Application.Factories.Patient;
using Application.Factories.Session;

using Microsoft.Extensions.DependencyInjection;

namespace Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this  IServiceCollection services)
    {
        return services
            .AddScoped<IAdminCommandHandlerFactory, AdminCommandHandlerFactoryImpl>()
            .AddScoped<IAppointmentCommandHandlerFactory, AppointmentCommandHandlerFactoryImpl>()
            .AddScoped<IDoctorCommandHandlerFactory, DoctorCommandHandlerFactoryImpl>()
            .AddScoped<IPatientCommandHandlerFactory, PatientCommandHandlerFactoryImpl>()
            .AddScoped<ISessionCommandHandlerFactory, SessionCommandHandlerFactoryImpl>();
    }
}
