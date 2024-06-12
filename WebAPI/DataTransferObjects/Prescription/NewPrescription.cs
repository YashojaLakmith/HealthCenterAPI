namespace WebAPI.DataTransferObjects.Prescription;

public record NewPrescription(
    string UserId,
    IReadOnlyCollection<PrescribedMedicine> PrescribedMedicine
    );
