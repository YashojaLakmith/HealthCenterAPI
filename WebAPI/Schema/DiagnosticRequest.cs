using System.ComponentModel.DataAnnotations;

namespace WebAPI.Schema;

public class DiagnosticRequest
{
    [Key]
    public string RequestId { get; set; }
    public DateTime RequestedDate { get; set; }

    public DiagnosticTypes DiagnosticType { get; set; }
    public Doctor RequestedDoctor { get; set; }
    public PatientBase Patient { get; set; }
    public MedicalReport? MedicalReport { get; set; }

    public DiagnosticRequest() { }

    public static DiagnosticRequest CreateDiagnosticRequest(DiagnosticTypes diagnosticType, Doctor doctor, PatientBase patient)
    {
        return new DiagnosticRequest()
        {
            RequestId = Guid.NewGuid().ToString(),
            RequestedDate = DateTime.Now,
            RequestedDoctor = doctor,
            Patient = patient,
            DiagnosticType = diagnosticType
        };
    }

    public void AttachReport(MedicalReport medicalReport)
    {
        if (MedicalReport is not null)    // check for invalid type
        {
            
        }

        MedicalReport = medicalReport;
    }
}
