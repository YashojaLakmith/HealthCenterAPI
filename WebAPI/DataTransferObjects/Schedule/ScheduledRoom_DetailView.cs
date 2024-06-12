namespace WebAPI.DataTransferObjects.Schedule;

public record ScheduledRoom_DetailView(
    string ScheduleId,
    uint RoomNumber,
    Common.Doctor Doctor,
    DateTime ScheduledDateTime,
    uint SessionDurationInMinutes
    );
