namespace WebAPI.DataTransferObjects.Appointment;

public record AppointmentDetaiView_Patient(
    string AppointmentId,
    Common.Doctor Doctor,
    SessionInformation SessionInformation,
    string AppointmentStatus
    );
