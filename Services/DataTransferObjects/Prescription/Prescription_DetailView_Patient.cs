using Services.DataTransferObjects.Common;

namespace Services.DataTransferObjects.Prescription;

public record Prescription_DetailView_Patient(
    string PrescriptionId,
    Doctor IssuedDoctor,
    DateTime CreatedDateTime,
    IReadOnlyCollection<PrescribedMedicine> PrescribedMedicine,
    string IssueStatus
    );
