using Services.DataTransferObjects.Common;

namespace Services.DataTransferObjects.Schedule;

public record ScheduledRoom_DetailView(
    string ScheduleId,
    uint RoomNumber,
    Doctor Doctor,
    DateTime ScheduledDateTime,
    uint SessionDurationInMinutes
    );
