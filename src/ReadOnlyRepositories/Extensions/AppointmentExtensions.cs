using Application.Appointment.Views;
using Domain.Entities;

namespace ReadOnlyRepositories.Extensions;

internal static class AppointmentExtensions
{
    internal static AppointmentDetailView AsDetailView(this Appointment appointment)
    {
        return new AppointmentDetailView(
            appointment.Id.Value,
            appointment.Patient.Id.Value,
            appointment.Patient.PatientName.Value,
            appointment.Session.Id.Value,
            appointment.Status);
    }

    internal static AppointmentListItemView AsListItem(this Appointment appointment)
    {
        return new AppointmentListItemView(
            appointment.Id.Value,
            appointment.Patient.Id.Value,
            appointment.Session.Id.Value);
    }
}