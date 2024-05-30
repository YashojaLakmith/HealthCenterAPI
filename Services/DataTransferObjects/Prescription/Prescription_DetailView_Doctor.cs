using Services.DataTransferObjects.Common;

namespace Services.DataTransferObjects.Prescription;

public record Prescription_DetailView_Doctor(
    string PrescriptionId,
    Patient PatientInformation,
    DateTime CreatedDateTime,
    IReadOnlyCollection<PrescribedMedicine> PrescribedMedicine,
    string IssueStatus
    );
