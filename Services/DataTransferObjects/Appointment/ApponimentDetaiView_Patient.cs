using Services.DataTransferObjects.Common;

namespace Services.DataTransferObjects.Appointment;

public record ApponimentDetaiView_Patient(
    string AppointmentId,
    Doctor Doctor,
    SessionInformation SessionInformation,
    string AppointmentStatus
    );
