using Authentication.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Abstractions;
public interface IApplicationDbContext
{
    public DbSet<Patient> Patients { get; }
    public DbSet<Doctor> Doctors { get; }
    public DbSet<Appointment> Appointments { get; }
    public DbSet<Session> Sessions { get; }
    public DbSet<Admin> Admins { get; }
    public DbSet<Credentials> Credentials { get; }
}
