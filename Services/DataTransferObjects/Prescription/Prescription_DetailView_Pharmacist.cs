namespace Services.DataTransferObjects.Prescription;

public record Prescription_DetailView_Pharmacist(
    string PrescriptionId,
    Common.Patient Patient,
    Common.Doctor IssuedDoctor,
    DateTime CreatedDateTime,
    IReadOnlyCollection<PrescribedMedicine> PrescribedMedicine
    );
