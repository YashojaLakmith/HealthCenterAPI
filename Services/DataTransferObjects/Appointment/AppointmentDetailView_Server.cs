namespace Services.DataTransferObjects.Appointment;

public record AppointmentDetailView_Server(
    string AppointmentId,
    Common.Patient Patient,
    Common.Doctor Doctor,
    SessionInformation SessionInformation,
    string AppointmentStatus
    );
