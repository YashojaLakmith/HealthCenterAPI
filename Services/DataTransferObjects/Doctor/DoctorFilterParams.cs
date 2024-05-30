namespace Services.DataTransferObjects.Doctor;

public record DoctorFilterParams(
    string? DoctorName,
    string? Specialization
    );
