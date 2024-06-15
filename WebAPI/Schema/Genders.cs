using System.ComponentModel.DataAnnotations;

namespace WebAPI.Schema;

public class Genders
{
    [Key]
    public string Gender { get; set; }

    public IReadOnlyCollection<EmployeeBase> Employees { get; set; }
    public IReadOnlyCollection<PatientBase> Patients { get; set; }

    public Genders() { }

    public static Genders Create(string identifier)
    {
        return new Genders() { Gender = identifier };
    }
}
