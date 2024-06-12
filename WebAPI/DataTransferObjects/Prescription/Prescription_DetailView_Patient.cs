namespace WebAPI.DataTransferObjects.Prescription;

public record Prescription_DetailView_Patient(
    string PrescriptionId,
    Common.Doctor IssuedDoctor,
    DateTime CreatedDateTime,
    IReadOnlyCollection<PrescribedMedicine> PrescribedMedicine,
    string IssueStatus
    );
