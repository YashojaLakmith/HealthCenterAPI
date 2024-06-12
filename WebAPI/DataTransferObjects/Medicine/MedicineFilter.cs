namespace WebAPI.DataTransferObjects.Medicine;

public record MedicineFilter(
    string? MedicineName,
    string? BrandName,
    string? MedicineFamily
    );
