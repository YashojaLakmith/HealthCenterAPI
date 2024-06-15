using System.ComponentModel.DataAnnotations;

namespace WebAPI.Schema;

public class MedicalReport
{
    [Key]
    public string ReportId { get; set; }
    public string Resource { get; set; }
    public DateTime IssuedOn { get; set; }

    public LabWorker Issuer { get; set; }

    public override bool Equals(object? obj)
    {
        if(obj is MedicalReport m)
        {
            return GetHashCode() == m.GetHashCode() && ReportId.Equals(m.ReportId);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return ReportId.GetHashCode();
    }
}
