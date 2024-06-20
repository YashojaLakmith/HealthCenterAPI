using System.Data;

using Authentication.Entities;

using Domain.Common;
using Domain.Entities;
using Domain.Repositories;

using Infrastructure.Abstractions;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure;

internal class ApplicationDbContext : DbContext, IUnitOfWork, IApplicationDbContext
{
    private readonly IDbConnectionStringSource _connStringSource;
    private readonly ILogger _logger;

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Admin> Users { get; set; }
    public DbSet<Credentials> Credentials { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
        IDbConnectionStringSource connectionStringSource,
        ILogger logger) : base(options)
    {
        _connStringSource = connectionStringSource;
        _logger = logger;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Infrastructure.DependencyInjection).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        try
        {
            var connString = _connStringSource.GetConnectionString();
            optionsBuilder.UseSqlServer(connString);
        }
        catch(Exception ex)
        {
            _logger.LogCritical("Error obtaining the database connection string: {@Exception}", ex);
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
