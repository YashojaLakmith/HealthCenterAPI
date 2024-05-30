namespace Services.DataTransferObjects.Medicine;

public record Medicine_DetaiView_Doctor(
    string MedicineId,
    string MedicineName,
    string Family,
    string UnitofMeasurement,
    double MeasurementUnits
    );
