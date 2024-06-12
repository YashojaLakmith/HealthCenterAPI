namespace WebAPI.DataTransferObjects.Prescription;

public record Prescription_DetailView_Doctor(
    string PrescriptionId,
    Common.Patient PatientInformation,
    DateTime CreatedDateTime,
    IReadOnlyCollection<PrescribedMedicine> PrescribedMedicine,
    string IssueStatus
    );
