namespace Services.DataTransferObjects.Medicine;

public record NewMedicine(
    string BrandName,
    string MedicineName,
    string Family,
    double UnitOfMeasurement,
    Pricing Pricing
    );