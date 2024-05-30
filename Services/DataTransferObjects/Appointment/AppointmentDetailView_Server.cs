using Services.DataTransferObjects.Common;

namespace Services.DataTransferObjects.Appointment;

public record AppointmentDetailView_Server(
    string AppointmentId,
    Patient Patient,
    Doctor Doctor,
    SessionInformation SessionInformation,
    string AppointmentStatus
    );
