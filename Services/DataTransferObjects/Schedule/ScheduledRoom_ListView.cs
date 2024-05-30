namespace Services.DataTransferObjects.Schedule;

public record ScheduledRoom_ListView(
    string ScheduleId,
    uint RoomNumber,
    DateTime SessionStart,
    uint SessionDurationInMinutes
    );
