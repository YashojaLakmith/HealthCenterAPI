namespace WebAPI.DataTransferObjects.Medicine;

public record MedicinePricing(
    string UnitOfPricing,
    double MeasurementUnitsPerPricingUnit,
    decimal PricePerPricingUnit
    );
