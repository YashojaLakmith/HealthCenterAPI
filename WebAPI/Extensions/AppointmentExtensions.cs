using WebAPI.DataTransferObjects.Appointment;
using WebAPI.Schema;

namespace WebAPI.Extensions;

public static class AppointmentExtensions
{
    public static AppointmentListItem_Patient ToListItem_Patient(this Appointment appointment)
    {
        return new AppointmentListItem_Patient(appointment.AppointmentId, appointment.Session.SessionStart, appointment.AppointmentState.ToString());
    }

    public static AppointmentDetailView_Server ToDetailView_Server(this Appointment appointment)
    {
        var patient = appointment.Patient;
        var doctor = appointment.Session.Doctor;
        var session = appointment.Session;

        return new AppointmentDetailView_Server(appointment.AppointmentId,
            new DataTransferObjects.Common.Patient(patient.PatientId, patient.PatientName, patient.Gender.Gender, CalculateAge(patient.BirthDate)),
            new DataTransferObjects.Common.Doctor(doctor.EmployeeId, doctor.EmployeeName, doctor.Description),
            new SessionInformation(uint.Parse(session.Room.Room), session.SessionStart, (uint)session.SessionDurationMinutes),
            appointment.AppointmentState.ToString());
    }

    public static AppointmentDetaiView_Patient ToDetailView_Patient(this Appointment appointment)
    {
        var doctor = appointment.Session.Doctor;
        var session = appointment.Session;

        return new AppointmentDetaiView_Patient(appointment.AppointmentId,
            new DataTransferObjects.Common.Doctor(doctor.EmployeeId, doctor.EmployeeName, doctor.Description),
            new SessionInformation(uint.Parse(session.Room.Room), session.SessionStart, (uint)session.SessionDurationMinutes),
            appointment.AppointmentState.ToString());
    }

    public static AppointmentListItem_Server ToListItem_Server(this Appointment appointment)
    {
        var patient = appointment.Patient;
        var session = appointment.Session;

        return new AppointmentListItem_Server(patient.PatientId, patient.PatientName, session.SessionStart, appointment.AppointmentState.ToString());
    }

    private static uint CalculateAge(DateTime dateOfBirth)
    {
        var current = DateTime.Now;
        var totalMonths = (dateOfBirth.Year * 12) + dateOfBirth.Month;
        var currentMonths = (current.Year * 12) + current.Month;

        return (uint)(currentMonths - totalMonths) / 12;
    }
}
