using Authentication.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Abstractions;
public interface IApplicationDbContext
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Admin> Users { get; set; }
    public DbSet<Credentials> Credentials { get; set; }
}
