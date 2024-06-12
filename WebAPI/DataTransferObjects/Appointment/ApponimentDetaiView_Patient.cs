namespace WebAPI.DataTransferObjects.Appointment;

public record ApponimentDetaiView_Patient(
    string AppointmentId,
    Common.Doctor Doctor,
    SessionInformation SessionInformation,
    string AppointmentStatus
    );
