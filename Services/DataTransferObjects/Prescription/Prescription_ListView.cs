namespace Services.DataTransferObjects.Prescription;

public record Prescription_ListView(
    string PrescriptionId,
    DateTime CreatedDateTime,
    string IssueStatus
    );
