namespace Services.DataTransferObjects.Prescription;

public record PrescribedMedicine(
    string MedicineName,
    string UnitOfMeasurement,
    double Units,
    uint DosagePerDay
    );
