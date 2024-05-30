using Services.DataTransferObjects.Common;

namespace Services.DataTransferObjects.Prescription;

public record Prescription_DetailView(
    string PrescriptionId,
    Patient Patient,
    Doctor IssuedDoctor,
    DateTime CreatedDateTime,
    IReadOnlyCollection<PrescribedMedicine> PrescribedMedicine,
    PrescriptionIssueStatus PrescriptionIssueStatus
    );
