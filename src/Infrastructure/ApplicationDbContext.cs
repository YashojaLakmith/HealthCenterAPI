using Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ApplicationDbContext : DbContext
{
    private readonly string _connString;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDbConnectionString connectionString) : base(options)
    {
        var task = connectionString.GetConnectionStringAsync();
        _connString = GetConnectionString(task);
    }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Appointments { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<User> Users { get; set; }

    private static string GetConnectionString(Task<string> connectionStringTask)
    {
        connectionStringTask.Wait();
        return connectionStringTask.Result;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Infrastructure.AssemblyReference).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connString);
    }
}
