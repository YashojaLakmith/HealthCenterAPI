namespace Domain.Common.Errors;
public static class AppointmentErrors
{
    private const string ErrorCodeFamily = @"Appointments";

    public static readonly Error MarkingNonPendingAppointmentAsPatientArrived = new($@"{ErrorCodeFamily}.NotPendingAppointment", @"Cannot mark the appointment as patient arrived if it is not in pending state.");

    public static readonly Error MarkingNonArrivedPatientAsServed = new($@"{ErrorCodeFamily}.PatientNotArrived", @"Cannot mark the appointment as served if the patient didn't arrived.");

    public static readonly Error EnrollingForSameSession = new($@"{ErrorCodeFamily}.SameSession", @"Patient already has an appointment for this session.");

    public static readonly Error AppointmentNotFound = new($@"{ErrorCodeFamily}.NotFound", @"Appointment not found.");

    public static readonly Error SessionHasEnded = new($@"{ErrorCodeFamily}.SessionEnded", @"This session has ended.");
}
