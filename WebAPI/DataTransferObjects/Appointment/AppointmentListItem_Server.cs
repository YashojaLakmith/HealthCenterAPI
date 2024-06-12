namespace WebAPI.DataTransferObjects.Appointment;

public record AppointmentListItem_Server(
    string UserId,
    string UserName,
    DateTime ApponitmentDateTime,
    string AppointmentStatus
    );
