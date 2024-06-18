using Authentication.Entities;

using Domain.Common;
using Domain.Entities;
using Domain.Repositories;

using Infrastructure.Abstractions;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

internal class ApplicationDbContext : DbContext, IUnitOfWork, IApplicationDbContext
{
    private readonly string _connString;

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Credentials> Credentials { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDbConnectionString connectionString) : base(options)
    {
        var task = connectionString.GetConnectionStringAsync();
        _connString = GetConnectionString(task);
    }

    private static string GetConnectionString(Task<Result<string>> connectionStringTaskResult)
    {
        connectionStringTaskResult.Wait();
        return connectionStringTaskResult.Result.Value;
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
