using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Schema;

public class DependentPatient : PatientBase
{
    [ForeignKey(nameof(IndependentPatient))]
    public string IndependentPatientId { get; set; }
    public IndependentPatient IndependentPatient { get; set; }

    public DependentPatient() { }

    public static DependentPatient CreateDependentPatient(string name, DateTime dateOfBirth, Genders gender, IndependentPatient independentPatient)
    {
        return new DependentPatient()
        {
            PatientId = Guid.NewGuid().ToString(),
            PatientName = name,
            BirthDate = dateOfBirth,
            Gender = gender,
            IndependentPatient = independentPatient,
            IndependentPatientId = independentPatient.PatientId,
            Appointments = [],
            Bills = [],
            DiagnosticRequests = [],
            DoctorNotes = string.Empty,
            Invoices = [],
            PatientCreatedOn = DateTime.Now,
            Prescriptions = [],
        };
    }
}
