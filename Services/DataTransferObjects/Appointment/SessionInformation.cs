namespace Services.DataTransferObjects.Appointment;

public record SessionInformation(
    uint RoomNumber,
    DateTime SessionStartsAt,
    uint SessionDurationInMinutes
    );
