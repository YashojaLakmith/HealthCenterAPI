namespace WebAPI.DataTransferObjects.Medicine;

public record Medicine_DetaiView(
    string MedicineId,
    string BrandName,
    string MedicineName,
    string Family,
    string UnitofMeasurement,
    double MeasurementUnits,
    MedicinePricing Pricing    
    );