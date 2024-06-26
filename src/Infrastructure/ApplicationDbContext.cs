using System.Data;

using Authentication.Entities;

using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using Infrastructure.Abstractions;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure;

internal class ApplicationDbContext : DbContext, IUnitOfWork, IApplicationDbContext
{
    private readonly IDbConnectionStringSource _connStringSource;
    private readonly ILogger<ApplicationDbContext> _logger;

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Credentials> Credentials { get; set; }

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IDbConnectionStringSource connectionStringSource,
        ILogger<ApplicationDbContext> logger ) : base(options)
    {
        _connStringSource = connectionStringSource;
        _logger = logger;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        try
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Infrastructure.DependencyInjection).Assembly);
        }
        catch (Exception ex)
        {
            _logger.LogCritical(@"And error occured while applying configurations. Error: {@Exception}", ex);
            Environment.Exit(1);
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        try
        {
            var connString = _connStringSource.GetConnectionString();
            optionsBuilder.UseSqlServer(connString, b =>
            {
                b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
            });
        }
        catch(Exception ex)
        {
            _logger.LogCritical("Error obtaining the database connection string: {@Exception}", ex);
            throw;
        }
    }

    async Task<Result> IUnitOfWork.SaveChangesAsync(CancellationToken cancellationToken)
    {
        try
        {
            await SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
        catch(DBConcurrencyException ex)
        {
            _logger.LogError("A concurrency violation has been detected. Exception: {@Exception}", ex);
            return Result.Failure(RepositoryErrors.ConcurrencyError);
        }
    }
}
