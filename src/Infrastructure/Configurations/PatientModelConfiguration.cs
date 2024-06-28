using Domain.Entities;
using Domain.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal sealed class PatientModelConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
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
                value => Id.CreateId(value));

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

        builder.Property(patient => patient.DateOfBirth)
            .IsRequired(true)
            .HasConversion(
                value => value.Value,
                value => DateOfBirth.Create(value).Value);

        builder.Property(patient => patient.NIC)
            .IsRequired(true)
            .HasConversion(
                value => value.Value,
                value => NIC.Create(value).Value);

        builder.HasKey(patient => patient.Id)
            .IsClustered(false);

        builder.HasIndex(patient => patient.EmailAddress)
            .IsClustered(false)
            .IsUnique(true);

        builder.HasIndex(patient => patient.PhoneNumber)
            .IsClustered(true)
            .IsUnique(true);
    }
}
