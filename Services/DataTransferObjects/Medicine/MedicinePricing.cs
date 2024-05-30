namespace Services.DataTransferObjects.Medicine;

public record MedicinePricing(
    string UnitOfPricing,
    double MeasurementUnitsPerPricingUnit,
    decimal PricePerPricingUnit
    );
