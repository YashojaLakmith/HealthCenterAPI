using Authentication.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
internal class CredentialModelConfiguration : IEntityTypeConfiguration<Credentials>
{
    public void Configure(EntityTypeBuilder<Credentials> builder)
    {
        builder.Ignore(cred => cred.Id);

        builder.Property(cred => cred.Admin)
            .IsRequired(true);

        builder.Property(cred => cred.PasswordHash)
            .IsRequired(true)
            .HasMaxLength(128);

        builder.Property(cred => cred.Salt)
            .IsRequired(true)
            .HasMaxLength(128);

        builder.HasNoKey();

        builder.HasOne(cred => cred.Admin)
            .WithOne()
            .HasForeignKey<Credentials>(cred => cred.Admin)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(cred => cred.Admin)
            .IsClustered(false)
            .IsUnique(true);
    }
}
