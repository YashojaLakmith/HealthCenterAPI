using System.ComponentModel.DataAnnotations;

namespace WebAPI.Schema;

public class MedicalReport
{
    [Key]
    public string ReportId { get; set; }
    public string Resource { get; set; }
    public DateTime IssuedOn { get; set; }

    public DiagnosticRequest DiagnosticRequest { get; set; }
    public LabWorker Issuer { get; set; }
}
