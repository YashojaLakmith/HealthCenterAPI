﻿namespace Services.DataTransferObjects.Schedule;

public record NewSchedule(
    uint RoomNumber,
    string DoctorId,
    DateTime SessionStart,
    uint SessionDurationInMinutes
    );
