﻿namespace Services.DataTransferObjects.Appointment;

public record AppointmentListItem_Patient(
    string AppointmentId,
    DateTime AppointmentDateTime,
    string AppointmentStatus
    );