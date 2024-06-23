using Domain.Entities;
using Domain.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal class AppointmentModelConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.Property(a => a.Id)
            .IsRequired(true)
            .HasConversion(
                value => value.Value,
                value => Id.CreateId(value).Value);

        builder.Property(a => a.AppointmentCreatedOn)
            .IsRequired(true);

        builder.Property(a => a.Status)
            .IsRequired(true);

        builder.HasKey(a => a.Id)
            .IsClustered(false);

        builder.HasOne(a => a.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(@"PatientId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
