using Domain.Entities;
using Domain.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal sealed class DoctorModelConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.Property(doc => doc.Id)
            .IsRequired(true)
            .HasConversion(
                value => value.Value,
                value => Id.CreateId(value).Value);

        builder.Property(doc => doc.DoctorDescription)
            .IsRequired(true)
            .HasConversion(
                value => value.Value,
                value => Description.CreateDescription(value).Value)
            .HasColumnType(@"NVARCHAR(500)");

        builder.Property(doc => doc.DoctorName)
            .IsRequired(true)
            .HasConversion(
                value => value.Value,
                value => Name.Create(value).Value)
            .HasColumnType(@"NVARCHAR(100)");

        builder.Property(doc => doc.Gender)
            .IsRequired(true);

        builder.Property(doc => doc.RegistrationNumber)
            .IsRequired(true)
            .HasConversion(
                value => value.Value,
                value => DoctorRegistrationNumber.Create(value).Value)
            .HasColumnType(@"NVARCHAR(15)");

        builder.Property(doc => doc.PhoneNumber)
            .IsRequired(true)
            .HasConversion(
                value => value.Value,
                value => PhoneNumber.CreatePhoneNumber(value).Value)
            .HasColumnType(@"VARCHAR(10)");

        builder.Property(doc => doc.DoctorEmailAddress)
            .IsRequired(true)
            .HasColumnType(@"VARCHAR(256)")
            .HasConversion(
                value => value.Value,
                value => EmailAddress.CreateEmailAddress(value).Value);

        builder.HasKey(doc => doc.Id)
            .IsClustered(false);

        builder.HasIndex(doc => doc.RegistrationNumber)
            .IsUnique(true)
            .IsClustered(false);

        builder.HasIndex(doc => doc.DoctorEmailAddress)
            .IsUnique(true)
            .IsClustered(false);
    }
}
