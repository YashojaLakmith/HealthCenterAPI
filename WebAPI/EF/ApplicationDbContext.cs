using Microsoft.EntityFrameworkCore;

using WebAPI.Schema;

namespace WebAPI.EF;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {       
    }

    public DbSet<AdminRoles> AdminRoles { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Bill> Bills { get; set; }
    public DbSet<CounterReceptionist> CounterReceptionists { get; set; }
    public DbSet<Credentials> Credentials { get; set; }
    public DbSet<DependentPatient> DependentPatients { get; set; }
    public DbSet<DiagnosticRequest> DiagnosticRequests { get; set; }
    public DbSet<DiagnosticTypes> DiagnosticTypes { get; set; }
    public DbSet<PatientBase> PatientBase { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Genders> Genders { get; set; }
    public DbSet<IndependentPatient> IndividualPatients { get; set; }
    public DbSet<LabWorker> LabWorkers { get; set; }
    public DbSet<MedicalReport> MedicalReports { get; set; }
    public DbSet<Medicine> Medicines { get; set; }
    public DbSet<MedicineTypes> MedicineTypes { get; set; }
    public DbSet<PaymentInvoice> PaymentInvoices { get; set; }
    public DbSet<PaymentMethods> PaymentMethods { get; set; }
    public DbSet<Pharmacist> Pharmacists { get; set; }
    public DbSet<PrescribedMedicine> PrescribedMedicines { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Query> Queries { get; set; }
    public DbSet<Rooms> Rooms { get; set; }
    public DbSet<Sessions> Sessions { get; set; }
    public DbSet<SysAdmin> SysAdmins { get; set; }
    public DbSet<UnitsOfMedicineMeasurement> UnitsOfMedicines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IndependentPatient>()
            .HasMany(i => i.DependentPatients)
            .WithOne(d => d.IndependentPatient)
            .HasForeignKey(d => d.IndependentPatientId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}

public static class PersistanceExtensions
{
    public static void AddEFCore(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HealthCenter;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        });
    }
}
