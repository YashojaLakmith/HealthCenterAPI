using Services.DataTransferObjects.Common;

namespace Services.DataTransferObjects.Prescription;

public record Prescription_DetailView_Pharmacist(
    string PrescriptionId,
    Patient Patient,
    Doctor IssuedDoctor,
    DateTime CreatedDateTime,
    IReadOnlyCollection<PrescribedMedicine> PrescribedMedicine
    );
