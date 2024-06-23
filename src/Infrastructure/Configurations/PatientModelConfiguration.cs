using Domain.Entities;
using Domain.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal class PatientModelConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.Ignore(patient => patient.Age);

        builder.Property(patient => patient.Appointments)
            .HasField(@"_appointments");

        builder.Property(patient => patient.DateOfBirth)
            .IsRequired(true);

        builder.Property(patient => patient.EmailAddress)
            .IsRequired(true)
            .HasConversion(
                value => value.Value,
                value => EmailAddress.CreateEmailAddress(value).Value)
            .HasColumnType(@"NVARCHAR(256)");

        builder.Property(patient => patient.Gender)
            .IsRequired(true);

        builder.Property(patient => patient.Id)
            .IsRequired(true)
            .HasConversion(
                value => value.Value,
                value => Id.CreateId(value).Value);

        builder.Property(patient => patient.PatientName)
            .IsRequired(true)
            .HasConversion(
                value => value.Value,
                value => Name.Create(value).Value)
            .HasColumnType(@"NVARCHAR(100)");

        builder.Property(patient => patient.PhoneNumber)
            .IsRequired(true)
            .HasConversion(
                value => value.Value,
                value => PhoneNumber.CreatePhoneNumber(value).Value)
            .HasColumnType(@"NVARCHAR(10)");

        builder.HasKey(patient => patient.Id)
            .IsClustered(false);

        builder.HasIndex(patient => patient.EmailAddress)
            .IsClustered(false)
            .IsUnique(true);
    }
}
