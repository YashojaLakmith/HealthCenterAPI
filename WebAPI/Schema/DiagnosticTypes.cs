using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Schema;

public class DiagnosticTypes : IPayedService
{
    [Key]
    public string DiagnosticTypeName { get; private set; }
    public string DiagnosticTypeDescription { get; private set; }
    public decimal ServicePrice { get; private set; }

    [NotMapped]
    public string ServiceDescription { get => DiagnosticTypeDescription; }
    [NotMapped]
    public string ServiceName { get => DiagnosticTypeName; }

    public DiagnosticTypes() { }

    public static DiagnosticTypes CreateDiagnosticType(string typeName, string description, decimal price)
    {
        return new DiagnosticTypes()
        {
            DiagnosticTypeName = typeName,
            DiagnosticTypeDescription = description,
            ServicePrice = price
        };
    }

    public void ChangeDescription(string newDescription)
    {
        throw new NotImplementedException();
    }

    public void ChangePrice(decimal price)
    {
        throw new NotImplementedException();
    }
}
