namespace Services.DataTransferObjects.Prescription;

public record PrescriptionIssueStatus
{
    public PrescriptionIssueStatus(string pharmacistId, string pharmacistName)
    {
        HasIssued = true;
        PharmacistId = pharmacistId;
        PharmacistName = pharmacistName;
    }

    public PrescriptionIssueStatus()
    {
        HasIssued = false;
    }

    public bool HasIssued { get; init; }
    public string? PharmacistId { get; init; }
    public string? PharmacistName { get; init; }
}
