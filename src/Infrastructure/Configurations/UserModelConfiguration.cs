using Domain.Entities;
using Domain.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
internal class UserModelConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(user => user.CreatedOn)
            .IsRequired(true);

        builder.Property(user => user.EmailAddress)
            .IsRequired(true)
            .HasConversion(
                value => value.Value,
                value => EmailAddress.CreateEmailAddress(value).Value)
            .HasColumnType(@"NVARCHAR(256)");

        builder.Property(user => user.Gender)
            .IsRequired(true);

        builder.Property(user => user.Id)
            .IsRequired(true)
            .HasConversion(
                value => value.Value,
                value => Id.CreateId(value).Value);

        builder.Property(user => user.NIC)
            .IsRequired(true)
            .HasConversion(
                value => value.Value,
                value => NIC.Create(value).Value)
            .HasColumnType(@"VARCHAR(12)");

        builder.Property(user => user.PhoneNumber)
            .IsRequired(true)
            .HasConversion(
                value => value.Value,
                value => PhoneNumber.CreatePhoneNumber(value).Value)
            .HasColumnType(@"VARCHAR(10)");

        builder.Property(user => user.Role)
            .IsRequired(true);

        builder.HasKey(user => user.Id)
            .IsClustered(false);

        builder.HasIndex(user => user.EmailAddress)
            .IsClustered(false)
            .IsUnique(true);
    }
}
