using Authentication.Entities;

using Domain.Entities;
using Domain.Repositories;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ApplicationDbContext : DbContext, IUnitOfWork
{
    private readonly string _connString;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDbConnectionString connectionString) : base(options)
    {
        var task = connectionString.GetConnectionStringAsync();
        _connString = GetConnectionString(task);
    }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Credentials> Credentials { get; set; }

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
