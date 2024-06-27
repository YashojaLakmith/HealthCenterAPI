using Domain.Entities;
using Domain.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal sealed class AppointmentModelConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.Ignore(a => a.Patient);
        
        builder.Property(a => a.Id)
            .IsRequired(true)
            .HasConversion(
                value => value.Value,
                value => Id.CreateId(value));

        builder.Property(a => a.AppointmentCreatedOn)
            .IsRequired(true);

        builder.Property(a => a.Status)
            .IsRequired(true);

        builder.HasKey(a => a.Id)
            .IsClustered(false);

        builder.HasOne(a => a.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(@"PatientId")
            .IsRequired(true)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
