using System.ComponentModel.DataAnnotations;

namespace WebAPI.Schema;

public class DiagnosticTypes
{
    [Key]
    public string DiagnosticTypeId { get; set; }
    public string DiagnosticTypeName { get; set; }
    public string DiagnosticTypeDescription { get; set; }
    public decimal PricePerDiagnosys { get; set; }

    public ICollection<DiagnosticRequest> DiagnosticRequests { get; set; }
}
