using Domain.Entities;
using Domain.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
internal sealed class AdminModelConfiguration : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder.Property(admin => admin.CreatedOn)
            .IsRequired(true);

        builder.Property(admin => admin.EmailAddress)
            .IsRequired(true)
            .HasConversion(
                value => value.Value,
                value => EmailAddress.CreateEmailAddress(value).Value)
            .HasColumnType(@"NVARCHAR(256)");

        builder.Property(admin => admin.Gender)
            .IsRequired(true);

        builder.Property(admin => admin.Id)
            .IsRequired(true)
            .HasConversion(
                value => value.Value,
                value => Id.CreateId(value));

        builder.Property(admin => admin.NIC)
            .IsRequired(true)
            .HasConversion(
                value => value.Value,
                value => NIC.Create(value).Value)
            .HasColumnType(@"VARCHAR(12)");

        builder.Property(admin => admin.PhoneNumber)
            .IsRequired(true)
            .HasConversion(
                value => value.Value,
                value => PhoneNumber.CreatePhoneNumber(value).Value)
            .HasColumnType(@"VARCHAR(10)");

        builder.Property(admin => admin.AdminName)
            .IsRequired(true)
            .HasConversion(
                value => value.Value,
                value => Name.Create(value).Value)
            .HasColumnType(@"NVARCHAR(100)");

        builder.Property(admin => admin.Role)
            .IsRequired(true);

        builder.HasKey(admin => admin.Id)
            .IsClustered(false);

        builder.HasIndex(admin => admin.EmailAddress)
            .IsClustered(false)
            .IsUnique(true);
    }
}
