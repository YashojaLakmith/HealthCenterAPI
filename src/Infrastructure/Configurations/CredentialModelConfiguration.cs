using Authentication.Entities;
using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
internal sealed class CredentialModelConfiguration : IEntityTypeConfiguration<Credentials>
{
    public void Configure(EntityTypeBuilder<Credentials> builder)
    {
        builder.Property(cred => cred.Id)
            .HasConversion(
                value => value.Value,
                value => Id.CreateId(value));

        builder.Property(cred => cred.PasswordHash)
            .IsRequired(true)
            .HasMaxLength(256);

        builder.Property(cred => cred.Salt)
            .IsRequired(true)
            .HasMaxLength(256);

        builder.HasKey(cred => cred.Id)
            .IsClustered(false);

        builder
            .HasOne(cred => cred.Admin)
            .WithOne()
            .HasForeignKey<Credentials>(cred => cred.Id)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
