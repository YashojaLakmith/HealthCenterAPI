namespace WebAPI.DataTransferObjects.Prescription;

public record Prescription_DetailView(
    string PrescriptionId,
    Common.Patient Patient,
    Common.Doctor IssuedDoctor,
    DateTime CreatedDateTime,
    IReadOnlyCollection<PrescribedMedicine> PrescribedMedicine,
    PrescriptionIssueStatus PrescriptionIssueStatus
    );
