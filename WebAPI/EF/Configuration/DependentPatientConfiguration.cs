using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WebAPI.Schema;

namespace WebAPI.EF.Configuration;

public class DependentPatientConfiguration : IEntityTypeConfiguration<DependentPatient>
{
    public void Configure(EntityTypeBuilder<DependentPatient> builder)
    {
        builder.HasKey(e => e.PatientId);

        builder.Property(e => e.PatientId)
            .HasMaxLength(38)
            .HasColumnType(@"varchar(38)");
    }
}
