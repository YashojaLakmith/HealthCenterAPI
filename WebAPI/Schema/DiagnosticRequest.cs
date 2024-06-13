using System.ComponentModel.DataAnnotations;

namespace WebAPI.Schema;

public class DiagnosticRequest
{
    [Key]
    public string RequestId { get; set; }
    public DateTime RequestedDate { get; set; }

    public DiagnosticTypes DiagnosticType { get; set; }
    public Doctor? RequestedDoctor { get; set; }
    public PatientBase Patient { get; set; }
    public MedicalReport? MedicalReport { get; set; }
}
